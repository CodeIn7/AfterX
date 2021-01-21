import React, { Component, useState } from 'react';
import { Form, Button, TimePicker, Select, DatePicker, Row } from 'antd';
import moment from 'moment';
import axios from '../../axios';
import styles from './MyReservationsForm.module.css';

const { Option } = Select;
class MyReservationsForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cities: [],
      clubs: [],
    };
  }
  // const [componentSize, setComponentSize] = useState('default');
  onChange(time, timeString) {
    console.log(time, timeString);
  }

  onChange(value) {
    console.log(`selected ${value}`);
  }

  onBlur() {
    console.log('blur');
  }

  onFocus() {
    console.log('focus');
  }

  onSearch(val) {
    console.log('search:', val);
  }

  onFormLayoutChange = ({ size }) => {
    // setComponentSize(size);
  };
  componentDidMount() {
    axios.get('/cities').then((res) => {
      const cities = res.data.map((city) => {
        return { id: city.id, name: city.name };
      });

      this.setState({ cities });
    });
    axios.get('/clubs').then((res) => {
      const clubs = res.data.map((club) => {
        return { id: club.id, name: club.name };
      });
      this.setState({ clubs });
    });
  }
  render() {
    const { cities } = this.state;
    const { clubs } = this.state;
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
              onChange={this.onChange}
              onFocus={this.onFocus}
              onBlur={this.onBlur}
              onSearch={this.onSearch}
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
              style={{ width: '100%' }}
              placeholder="Select a club"
              optionFilterProp="children"
              onChange={this.onChange}
              onFocus={this.onFocus}
              onBlur={this.onBlur}
              onSearch={this.onSearch}
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
              <Button type="primary" htmlType="submit">
                Continue
              </Button>
            </Form.Item>
          </Row>
          {/* <Form.Item label={<label style={{ color: "white" }}>Pick date:</label>}>
          <DatePicker style={{ display: 'inline-block', width: 'calc(50% - 8px)' }} />
        </Form.Item>
        <Form.Item label={<label style={{ color: "white" }}>Pick time:</label>}>
            <TimePicker style={{ display: 'inline-block', width: 'calc(50% - 8px)', margin: '0' }} onChange={onChange} defaultOpenValue={moment('00:00:00', 'HH:mm:ss')} />
        </Form.Item> */}
        </Form>
      </>
    );
  }
}
export default MyReservationsForm;
