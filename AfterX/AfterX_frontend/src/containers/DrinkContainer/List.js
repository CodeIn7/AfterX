/* eslint-disable no-unused-vars */
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {
  Drawer,
  Form,
  Button,
  Col,
  Row,
  Input,
  Select,
  DatePicker,
  Table,
  Space,
} from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import axios from '../../axios';
import './List.css';
import 'antd/dist/antd.css';
import FormikForm from '../../components/FormikForm/FormikForm';
import config from './config';

// import { userService } from '../_services';
import { drinkService } from '../../_services/drinkService';

const { Option } = Select;

class List extends Component {
  constructor(props) {
    super(props);
    this.state = {
      visibleAddEdit: false,
      columns: [
        {
          title: 'Name',
          dataIndex: 'name',
          key: 'name',
          render: (text) => <a>{text}</a>,
        },
        {
          title: 'Quantity',
          dataIndex: 'quantity',
          key: 'quantity',
        },
        {
          title: 'Type',
          dataIndex: 'type',
          key: 'type',
        },
        {
          title: 'Action',
          key: 'action',
          render: (text, record) => (
            <Space size="middle">
              <a>Edit</a>
              <a>Delete</a>
            </Space>
          ),
        },
      ],

      data: [],
    };
  }

  componentDidMount() {
    axios.get('/drinks').then((response) => {
      this.formatResponseToState(response.data);
    });
  }

  showDrawer = () => {
    this.setState({
      visibleAddEdit: true,
    });
  };

  onClose = () => {
    this.setState({
      visibleAddEdit: false,
    });
  };

  formatResponseToState = (_data) => {
    const drinks = _data.map((drink) => ({
      key: drink.id,
      id: drink.id,
      name: drink.name,
      quantity: drink.quantity,
      type: drink.drinktype.name,
    }));
    this.setState({ data: drinks });
  };
  //   useEffect(() => {
  //     userService.getAll().then((x) => setUsers(x));
  //   }, []);

  render() {
    const { data, columns, visibleAddEdit } = this.state;
    const { path } = this.props;
    return (
      <div>
        <h1>Drinks</h1>
        <Button type="primary" onClick={this.showDrawer}>
          <PlusOutlined /> New account
        </Button>
        <Table columns={columns} dataSource={data} />
        <Drawer
          title="Create a new drink"
          width={720}
          onClose={this.onClose}
          visible={visibleAddEdit}
          bodyStyle={{ paddingBottom: 80 }}
          footer={
            <div
              style={{
                textAlign: 'right',
              }}
            >
              <Button onClick={this.onClose} style={{ marginRight: 8 }}>
                Cancel
              </Button>
              <Button onClick={this.onClose} type="primary">
                Submit
              </Button>
            </div>
          }
        >
          <FormikForm config={config} />
        </Drawer>
      </div>
    );
  }
}
List.propTypes = {
  path: PropTypes.string,
};
export default List;
