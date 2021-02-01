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
import axios from '../../axios';

export class ReservationListComponent extends Component {
  static propTypes = {};

  constructor(props) {
    super(props);
    this.state = {
      reservations: [],
      visibleAddEdit: false,
      columns: [
        {
          title: 'Table Type',
          dataIndex: 'tableType',
          key: 'tableType',
          render: (text) => <a>{text}</a>,
        },
        {
          title: 'Number of people',
          dataIndex: 'numberOfPeople',
          key: 'numberOfPeople',
        },
        {
          title: 'Table id',
          dataIndex: 'tableId',
          key: 'tableId',
        },
        {
          title: 'Action',
          key: 'action',
          render: (text, record) => (
            <Space size="middle">
              {console.log(text, record)}
              <Button
                type="primary"
                onClick={() =>
                  this.navigateTo(`/reservations/orders/${record.id}`)
                }
              >
                Ordres
              </Button>
              <Button onClick={() => this.deleteReservation(record.id)}>
                Delete
              </Button>
            </Space>
          ),
        },
      ],
    };
  }

  navigateTo = (URL) => {
    this.props.history.push(URL);
  };

  formatResponseToState = (_data) => {
    const reservations = _data.map((reservation) => ({
      id: reservation.id,
      key: reservation.id,
      numberOfPeople: reservation.numberofpeople,
      reservationDate: reservation.reservationdate,
      tableId: reservation.tableid,
      tableType: reservation.table.tabletype.name,
    }));
    this.setState({ data: reservations });
  };

  componentDidMount = () => {
    axios.get('reservations/userId').then((response) => {
      this.formatResponseToState(response.data);
    });
  };

  render() {
    const { columns, data } = this.state;
    return (
      <div>
        <Button onClick={() => this.navigateTo('/User')}>
          Add new reservation
        </Button>
        <Table columns={columns} dataSource={data} />
      </div>
    );
  }
}

export default ReservationListComponent;
