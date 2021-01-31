import React, { Component } from 'react';
import { PlusOutlined } from '@ant-design/icons';
import TextArea from 'antd/lib/input/TextArea';
import {
  Form,
  Button,
  TimePicker,
  Select,
  DatePicker,
  Card,
  Drawer,
  Col,
  InputNumber,
  Row,
} from 'antd';
import axios from '../../axios';

import './MyReservationsForm.css';

const { Option } = Select;
const { Meta } = Card;
const formItemLayout = {
  labelCol: {
    span: 24,
  },
  wrapperCol: {
    span: 24,
  },
};
class MyReservationsForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cities: [],
      clubs: [],
      tableTypes: [],

      visible: false,

      numberOfPeople: null,
      pickedTable: null,
      pickedDate: null,
      pickedCity: null,
      pickedClub: null,
    };
  }

  componentDidMount() {
    this.getFromUrl('/cities', (data) => {
      const cities = data.map((city) => ({ id: city.id, name: city.name }));

      this.setState({ cities });
    });
    this.getFromUrl('/tableTypes', (data) => {
      const tableTypes = data.map((type) => ({ id: type.id, name: type.name }));
      this.setState({ tableTypes });
    });
  }

  saveReservation = () => {
    if (this.checkCanBeSaved()) {
      const data = this.getReservationData();
      axios.post('/reservations', data).then((response) => {
        console.log(response);
        const { reservationId } = response.data;
        this.props.history.push(`/reservations/${reservationId}`);
      });
    }
  };

  getReservationData = () => {
    const { pickedClub, numberOfPeople, pickedTable, pickedDate } = this.state;
    const form = {
      ClubId: pickedClub,
      TableTypeId: pickedTable,
      Reservationdate: pickedDate,
      Numberofpeople: numberOfPeople,
    };
    return form;
  };

  checkCanBeSaved = () => {
    const {
      pickedCity,
      pickedClub,
      numberOfPeople,
      pickedTable,
      pickedDate,
    } = this.state;
    if (
      pickedCity &&
      pickedClub &&
      numberOfPeople &&
      pickedDate &&
      pickedTable
    ) {
      return true;
    }
    return false;
  };

  // const [componentSize, setComponentSize] = useState('default');

  handleClick = (value) => {
    this.setState({ pickedCity: value });
    axios.get(`/clubs/city/${value}`).then((res) => {
      console.log(res.data);
      const clubs = res.data.map((club) => ({ id: club.id, name: club.name }));
      this.setState({ clubs });
    });
  };

  getFromUrl = (url, _callback) => {
    axios
      .get(url)
      .then((response) => {
        _callback(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  handleContinueButton = () => {
    this.showDrawer();
  };

  showDrawer = () => {
    this.setState({
      visible: true,
    });
  };

  onClose = () => {
    this.setState({
      visible: false,
    });
  };

  onFormLayoutChange = ({ size }) => {
    // setComponentSize(size);
  };

  render() {
    const { cities, clubs, tableTypes, visible } = this.state;
    return (
      <>
        <Row justify="center">
          <h2 style={{ color: 'white' }}>Select city and club</h2>
        </Row>
        <Form
          style={{ width: '100%' }}
          wrapperCol={{
            span: 24,
          }}
          layout="horizontal"
          initialValues={
            {
              // size: componentSize,
            }
          }
          onValuesChange={this.onFormLayoutChange}
          // size={componentSize}
        >
          <Form.Item>
            <Select
              showSearch
              style={{ width: '100%' }}
              placeholder="Select a city"
              optionFilterProp="children"
              onChange={this.handleClick}
              filterOption={(input, option) =>
                option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
              }
            >
              {cities.map((city) => (
                <Option key={city.id} value={city.id}>
                  {city.name}
                </Option>
              ))}
            </Select>
          </Form.Item>
          <Form.Item>
            <Select
              showSearch
              disabled={clubs.length < 1}
              style={{ width: '100%' }}
              placeholder="Select a club"
              optionFilterProp="children"
              onChange={(e) => this.setState({ pickedClub: e })}
              filterOption={(input, option) =>
                option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
              }
            >
              {clubs.map((club) => (
                <Option key={club.id} value={club.id}>
                  {club.name}
                </Option>
              ))}
            </Select>
          </Form.Item>
          <Row justify="center">
            <Form.Item span={5}>
              <Button type="primary" onClick={this.handleContinueButton}>
                Continue
              </Button>
            </Form.Item>
          </Row>
          <Drawer
            title="Make reservation"
            width={520}
            closable={false}
            onClose={this.onClose}
            visible={visible}
          >
            <Form {...formItemLayout}>
              <Form.Item
                className="myLabel"
                name="numberOfPeople"
                label="How many people will be at the table?"
              >
                <InputNumber
                  style={{ width: '100%' }}
                  placeholder="Number of people"
                  onChange={(e) => this.setState({ numberOfPeople: e })}
                />
              </Form.Item>

              <Form.Item
                name="tableId"
                className="myLabel"
                label="Which table do you prefer?"
              >
                <Select
                  allowClear
                  placeholder="Select table"
                  onChange={(e) => this.setState({ pickedTable: e })}
                >
                  {tableTypes.map((type) => (
                    <Option key={type.id} value={type.id}>
                      {type.name}
                    </Option>
                  ))}
                </Select>
              </Form.Item>

              <Form.Item
                name="date-picker"
                label="Which date are you partying?"
                className="myLabel"
              >
                <DatePicker
                  style={{ width: '100%' }}
                  onChange={(date, dateString) =>
                    this.setState({ pickedDate: dateString })
                  }
                />
              </Form.Item>
              <Form.Item>
                <Button
                  type="primary"
                  htmlType="submit"
                  onClick={this.saveReservation}
                >
                  Submit
                </Button>
              </Form.Item>
            </Form>
          </Drawer>
        </Form>
      </>
    );
  }
}
export default MyReservationsForm;
