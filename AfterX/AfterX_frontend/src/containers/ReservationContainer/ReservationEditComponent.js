/* eslint-disable react/destructuring-assignment */
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import {
  Drawer,
  Form,
  Button,
  Col,
  Row,
  Card,
  Input,
  Select,
  TimePicker,
  Table,
  Space,
} from 'antd';
import { Formik } from 'formik';
import { DeleteOutlined } from '@ant-design/icons';
import moment from 'moment';
import FormikForm from '../../components/FormikForm/FormikForm';
import { orderConfig } from './config';

import axios from '../../axios';

const format = 'HH:mm';
const { Meta } = Card;
const { Option } = Select;

export class ReservationEditComponent extends Component {
  static propTypes = {};

  static layout = {
    labelCol: {
      span: 24,
    },
    wrapperCol: {
      span: 24,
    },
  };

  constructor(props) {
    super(props);
    this.state = {
      orders: [],
      columns: [
        {
          title: 'Active',
          dataIndex: 'active',
          key: 'active',
          render: (flag) => <a>{flag ? 'True' : 'False'}</a>,
        },
        {
          title: 'Time',
          dataIndex: 'time',
          key: 'time',
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
              <Button
                type="primary"
                // onClick={() =>}
              >
                Details
              </Button>
              <Button onClick={() => this.deleteOrderFromDb(record.id)}>
                Delete
              </Button>
            </Space>
          ),
        },
      ],
      reservationId: null,
      drinks: [],
      pickedDrinks: [],
      pickedDrinkToAdd: null,
      totalPrice: 0.0,
      visibleDrawer: false,
    };
  }

  componentDidMount() {
    this.init();
  }

  init = () => {
    const reservationId = this.props.match.params.id;
    this.setState({ reservationId });
    this.getFromUrl(`/orders/reservation/${reservationId}`, (data) => {
      this.formatOrdersToState(data);
    });
    this.getFromUrl(`/drinkClubs/reservation/${reservationId}`, (data) => {
      const drinks = data.map((drinkClub) => ({
        drinkId: drinkClub.drink.id,
        name: `${drinkClub.drink.name} ${drinkClub.drink.quantity}`,
        price: drinkClub.price,
      }));
      this.setState({ drinks });
    });
  };

  formatOrdersToState = (_orders) => {
    const orders = _orders.map((order) => ({
      id: order.id,
      key: order.id,
      note: order.note,
      active: order.active,
      tableId: order.tableid,
      time: new Date(`1970-01-01 ${order.time}`).toTimeString().split(' ')[0],
    }));
    this.setState({ orders });
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

  createNewDrinkCard = () => {
    const { pickedDrinkToAdd, drinks, pickedDrinks } = { ...this.state };
    const drink = { ...drinks.find((_d) => _d.drinkId === pickedDrinkToAdd) };

    pickedDrinks.push({ ...drink, nobottles: 0 });
    this.setState({ pickedDrinks });
  };

  deletePickedDrink = (index) => {
    const { pickedDrinks } = this.state;
    pickedDrinks.splice(index, 1);
    this.setState({ pickedDrinks });
  };

  deleteOrderFromDb = (orderId) => {
    axios.delete(`/orders/${orderId}`).then((response) => {
      console.log(response.data);
      this.init();
    });
  };

  setNoBottles = (event, index) => {
    event.preventDefault();
    const { pickedDrinks } = this.state;
    pickedDrinks[index].nobottles = event.target.value;
    this.setState({ pickedDrinks });
  };

  saveOrder = (formikValues) => {
    const { time, pickedDrinks, reservationId } = this.state;
    const data = {
      note: formikValues.note,
      time,
      drinks: pickedDrinks.map((drink) => ({
        drinkId: drink.drinkId,
        nobottles: drink.nobottles,
      })),
      Reservationid: parseInt(reservationId),
    };
    console.log(data);
    axios.post('/orders', data).then((response) => {
      this.setState({ visible: false });
      this.init();
    });
  };

  render() {
    const {
      columns,
      orders,
      drinks,
      pickedDrinks,
      totalPrice,
      visibleDrawer,
    } = this.state;
    return (
      <>
        <Table columns={columns} dataSource={orders} />
        <Button onClick={() => this.setState({ visibleDrawer: true })}>
          Add order
        </Button>
        <Drawer
          title="Make order"
          width={520}
          onClose={() => this.setState({ visibleDrawer: false })}
          visible={visibleDrawer}
        >
          <Formik
            initialValues={{}}
            validationSchema={{}}
            onSubmit={async (values, { setSubmitting }) => {
              await new Promise((r) => setTimeout(r, 500));
              this.saveOrder(values);
              setSubmitting(false);
            }}
          >
            {(_props) => {
              const {
                values,
                touched,
                errors,
                isSubmitting,
                handleChange,
                handleSubmit,
              } = _props;
              return (
                <Col span={24}>
                  <Form
                    {...this.layout}
                    style={{ width: '100%', padding: '3%' }}
                  >
                    <div>
                      <Form.Item
                        key="note"
                        className="myLabel"
                        style={{ color: 'white' }}
                      >
                        <Input
                          type="text"
                          name="note"
                          onChange={(e) => {
                            handleChange(e);
                          }}
                          style={{
                            margin: '10px',
                          }}
                          id="note"
                          placeholder="Note"
                          className={
                            errors.note && touched.note
                              ? 'text-input error'
                              : 'text-input'
                          }
                        />
                        {errors.note && touched.note && (
                          <div className="input-feedback">{errors.note}</div>
                        )}
                      </Form.Item>
                      <Form.Item>
                        <TimePicker
                          format={format}
                          minuteStep={15}
                          onChange={(d, time) => {
                            this.setState({ time });
                          }}
                        />
                      </Form.Item>
                      <Form.Item>
                        <Select
                          showSearch
                          style={{ width: 200 }}
                          placeholder="Select a drink"
                          optionFilterProp="children"
                          onChange={(e) =>
                            this.setState({ pickedDrinkToAdd: e })
                          }
                          filterOption={(input, option) =>
                            option.children
                              .toLowerCase()
                              .indexOf(input.toLowerCase()) >= 0
                          }
                        >
                          {drinks.map((drink) => (
                            <Option key={Math.random()} value={drink.drinkId}>
                              {drink.name}
                            </Option>
                          ))}
                        </Select>
                        <Button onClick={this.createNewDrinkCard}>Add</Button>
                      </Form.Item>
                      {pickedDrinks.map((drink, index) => (
                        <Card
                          key={Math.random()}
                          style={{ width: '100%', marginTop: 16 }}
                        >
                          <Row justify="space-between">
                            <Col span={4}>
                              <DeleteOutlined
                                onClick={() => this.deletePickedDrink(index)}
                              />
                            </Col>
                            <Col span={16}>
                              <Meta
                                title={drink.name}
                                description={`Price: ${drink.price}`}
                              />
                            </Col>
                            <Col span={4}>
                              <Input
                                type="number"
                                onChange={(e) => this.setNoBottles(e, index)}
                                value={drink.nobottles}
                              />
                            </Col>
                          </Row>
                        </Card>
                      ))}
                      {/* <Input type="number" disabled value={totalPrice} /> */}
                      <Row justify="center">
                        <Button
                          type="submit"
                          disabled={isSubmitting}
                          onClick={handleSubmit}
                        >
                          Submit
                        </Button>
                      </Row>
                    </div>
                  </Form>
                </Col>
              );
            }}
          </Formik>
        </Drawer>
      </>
    );
  }
}

export default ReservationEditComponent;
