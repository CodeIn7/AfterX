import React, { useState } from 'react';
import {
  Form,
  Button,
  TimePicker,
  Select,
  DatePicker,
  Row
} from 'antd';
import moment from 'moment';

import styles from './MyReservationsForm.module.css';

const MyReservationsForm = () => {
  const [componentSize, setComponentSize] = useState('default');
  function onChange(time, timeString) {
    console.log(time, timeString);
  }
  const onFormLayoutChange = ({ size }) => {
    setComponentSize(size);
  };
  return (
    <>
       <Form style={{width: '100%'}}
        labelCol={{
          span: 4,
        }}
        wrapperCol={{
          span: 24,
        }}
        layout="horizontal"
        initialValues={{
          size: componentSize,
        }}
        onValuesChange={onFormLayoutChange}
        size={componentSize}
      >
        <Form.Item>
          <Select placeholder="Club">
            <Select.Option value="demo">Demo</Select.Option>
          </Select>
        </Form.Item>
        <Form.Item>
          <Select placeholder="Club">
            <Select.Option value="demo">Demo</Select.Option>
          </Select>
        </Form.Item>
        <Form.Item span={5}>
        <Button type="primary" htmlType="submit">
          Continue
        </Button>
      </Form.Item>
        {/* <Form.Item label={<label style={{ color: "white" }}>Pick date:</label>}>
          <DatePicker style={{ display: 'inline-block', width: 'calc(50% - 8px)' }} />
        </Form.Item>
        <Form.Item label={<label style={{ color: "white" }}>Pick time:</label>}>
            <TimePicker style={{ display: 'inline-block', width: 'calc(50% - 8px)', margin: '0' }} onChange={onChange} defaultOpenValue={moment('00:00:00', 'HH:mm:ss')} />
        </Form.Item> */}
      </Form>
    </>
  );
};
export default MyReservationsForm;
