import React, { Component, useState } from 'react';
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
import moment from 'moment';
import axios from '../../axios';
import './MyReservationsForm.css';
import { PlusOutlined } from '@ant-design/icons';
import TextArea from 'antd/lib/input/TextArea';

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
  }
  state = {
    cities: [],
    clubs: [],
    clubsFlag: false,
    visible: false,
    childrenDrawer: false,
  };
  componentDidMount() {
    axios.get('/cities').then((res) => {
      const cities = res.data.map((city) => {
        return { id: city.id, name: city.name };
      });

      this.setState({ cities });
    });
  }
  // const [componentSize, setComponentSize] = useState('default');
  onChange(time, timeString) {
    console.log(time, timeString);
  }

  handleClick = (value) => {
    axios.get('/clubs/city/' + value).then((res) => {
      console.log(res.data);
      const clubs = res.data.map((club) => {
        return { id: club.id, name: club.name };
      });
      this.setState({ clubs });
    });
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

  showChildrenDrawer = () => {
    this.setState({
      childrenDrawer: true,
    });
  };

  onChildrenDrawerClose = () => {
    this.setState({
      childrenDrawer: false,
    });
  };

  onFormLayoutChange = ({ size }) => {
    // setComponentSize(size);
  };

  onFinish = (fieldValues) => {
    const values = {
      ...fieldValues,
      'date-picker': fieldValues['date-picker'].format('YYYY-MM-DD'),
      'time-picker': fieldValues['time-picker'].format('HH:mm:ss'),
    };
    console.log('Success:', values);
  };

  render() {
    const { cities, clubs } = this.state;
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
              onChange={this.onChange}
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
              <Button type="primary" onClick={this.showDrawer}>
                Continue
              </Button>
            </Form.Item>
          </Row>
          <Drawer
            title="Make reservation"
            width={520}
            closable={false}
            onClose={this.onClose}
            visible={this.state.visible}
          >
            <Form {...formItemLayout} onFinish={this.onFinish}>
              <Form.Item
                className="myLabel"
                name="numberOfPeople"
                label="How many people will be at the table?"
              >
                <InputNumber
                  style={{ width: '100%' }}
                  placeholder="Number of people"
                />
              </Form.Item>

              <Form.Item
                name="tableId"
                className="myLabel"
                label="Which table do you prefer?"
              >
                <Select allowClear placeholder="Select table">
                  <Option value="1">Option 1</Option>
                  <Option value="2">Option 2</Option>
                  <Option value="3">Option 3</Option>
                </Select>
              </Form.Item>

              <Form.Item
                name="date-picker"
                label="Which date are you partying?"
                className="myLabel"
              >
                <DatePicker style={{ width: '100%' }} />
              </Form.Item>
            </Form>
            <Card style={{ width: '100%', marginTop: 16 }}>
              <Row justify="space-between">
                <Col span={4}>
                  <Button
                    type="primary"
                    shape="circle"
                    onClick={this.showChildrenDrawer}
                    icon={<PlusOutlined />}
                    size="large"
                  />
                </Col>
                <Col span={20}>
                  <Meta
                    title="Add order"
                    description="Adding order requires drinks to select"
                  />
                </Col>
              </Row>
            </Card>
            <Drawer
              title="Add order"
              width={400}
              closable={false}
              onClose={this.onChildrenDrawerClose}
              visible={this.state.childrenDrawer}
            >
              <Form {...formItemLayout} onFinish={this.onFinish}>
                <Form.Item
                  className="myLabel"
                  name="note"
                  label="Do you have a note for bartender?"
                >
                  <TextArea style={{ width: '100%' }} placeholder="Note" />
                </Form.Item>

                <Form.Item
                  name="drinkId"
                  className="myLabel"
                  label="Which drinks do you want to order?"
                >
                  <Select allowClear placeholder="Select drinks">
                    <Option value="1">Option 1</Option>
                    <Option value="2">Option 2</Option>
                    <Option value="3">Option 3</Option>
                  </Select>
                </Form.Item>

                <Form.Item
                  name="time-picker"
                  label="Which time do you want your order to come?"
                  className="myLabel"
                >
                  <TimePicker style={{ width: '100%' }} />
                </Form.Item>
                <Form.Item>
                  <Button type="primary" htmlType="submit">
                    Submit
                  </Button>
                </Form.Item>
              </Form>
            </Drawer>
          </Drawer>
        </Form>
      </>
    );
  }
}
export default MyReservationsForm;
