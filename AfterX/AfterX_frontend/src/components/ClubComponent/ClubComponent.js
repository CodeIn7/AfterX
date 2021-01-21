/* eslint-disable guard-for-in */
/* eslint-disable no-undef */
/* eslint-disable no-restricted-syntax */
/* eslint-disable eqeqeq */
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Drawer, Button, Alert } from 'antd';

import { PlusOutlined } from '@ant-design/icons';
import FormikForm from '../FormikForm/FormikForm';
import { clubConfig } from './config';
import axios from '../../axios';

export class ClubComponent extends Component {
  //   static propTypes = {};

  constructor(props) {
    super(props);

    this.state = {
      club: {},
      drinks: [],
      tableTypes: [],

      clubToSubmit: {},
      drinksConfig: [],
      tablesConfig: [],

      drinkPricesToSubmit: {},
      tablesToSubmit: {},

      visibleAddDrinkPrices: false,
      visibleAddTables: false,

      showAlert: false,
      alert: null,
    };
  }

  componentDidMount = () => {
    this.getAllDrinks();
    this.getAllTablesType();
  };

  submitClub = () => {
    const postData = this.getClubPostData();
    console.log(postData);
    const { tablesToSubmit, drinkPricesToSubmit, clubToSubmit } = this.state;
    if (
      tablesToSubmit == {} ||
      drinkPricesToSubmit == {} ||
      clubToSubmit == {}
    ) {
      this.setAlert(true, 'warning', 'Warning', 'Submit all forms first');
      return;
    }
    axios.post('/clubs', postData).then((response) => {
      console.log(response);
    });
  };

  getClubPostData = () => {
    const { clubToSubmit, tablesToSubmit, drinkPricesToSubmit } = this.state;
    return {
      ClubName: clubToSubmit.clubName,
      Cityid: 3, // clubToSubmit.city,
      Street: clubToSubmit.street,
      Number: clubToSubmit.streetNumber,
      tables: tablesToSubmit,
      priceList: drinkPricesToSubmit,
    };
  };

  formatEmptyValues = (values) => {
    const _values = {};
    for (const id in values) {
      if (values[id] != '') {
        _values[id] = values[id];
      }
    }
    return _values;
  };

  drinksSubmitHandler = (values) => {
    this.setState({
      drinkPricesToSubmit: this.formatEmptyValues(values),
    });
  };

  clubSubmitHandler = (values) => {
    this.setState({
      clubToSubmit: this.formatEmptyValues(values),
    });
  };

  tablesSubmitHandler = (values) => {
    const tables = {};
    for (const id in values) {
      const value = values[id];
      console.log(id, values);
      const tableId = id.split('_')[0];
      if (tables[tableId] == undefined) tables[tableId] = {};
      const tableProperty = id.split('_')[1];
      tables[tableId][tableProperty] = value;
    }
    this.setState({
      tablesToSubmit: this.formatEmptyValues(tables),
    });
  };

  showDrinksDrawer = () => {
    this.setState({
      visibleAddDrinkPrices: true,
    });
  };

  showTablesDrawer = () => {
    this.setState({
      visibleAddTables: true,
    });
  };

  onClose = () => {
    this.setState({
      visibleAddTables: false,
      visibleAddDrinkPrices: false,
    });
  };

  getAllDrinks = () => {
    axios.get('/drinks').then((response) => {
      const drinksConfig = [];
      const drinks = response.data.map((drink) => {
        drinksConfig.push({
          type: 'number',
          field: `${drink.id}`,
          label: `${drink.name} ${drink.quantity}`,
          validationType: 'number',
          placeholder: 'Enter price in HRK',
          validations: [
            {
              type: 'min',
              params: [0, 'Min price is 0'],
            },
          ],
        });
        return {
          id: drink.id,
          quantity: drink.quantity,
          name: drink.name,
        };
      });

      this.setState({
        drinksConfig,
        drinks,
      });
    });
  };

  getAllTablesType = () => {
    axios.get('/tableTypes').then((response) => {
      const tablesConfig = [];
      const tables = response.data.map((table) => {
        console.log(table);
        tablesConfig.push({
          type: 'number',
          field: `${table.id}_numberOfTables`,
          label: `${table.name}-number of tables`,
          validationType: 'number',
          placeholder: `Enter number of  tables in club`,
          validations: [
            {
              type: 'min',
              params: [0, 'Min number of tables is 0'],
            },
            {
              type: 'required',
              params: ['Number of tables is required'],
            },
          ],
        });
        tablesConfig.push({
          type: 'number',
          field: `${table.id}_capacity`,
          label: `${table.name}-capacity`,
          validationType: 'number',
          placeholder: `Enter capacity for table`,
          validations: [
            {
              type: 'required',
              params: ['Capacity is required'],
            },
          ],
        });
        tablesConfig.push({
          type: 'number',
          field: `${table.id}_minnobottles`,
          label: `${table.name}-min number of bottles`,
          validationType: 'number',
          placeholder: `Enter min number of bottles for table`,
          validations: [
            {
              type: 'required',
              params: ['Min number of bottles is required'],
            },
          ],
        });
        return {
          id: table.id,
          name: table.name,
        };
      });
      console.log(tables, tablesConfig);
      this.setState({ tables, tablesConfig });
    });
  };

  setAlert = (showAlert, type, message, description) => {
    this.setState({ showAlert, alert: { type, message, description } });
  };

  render() {
    const {
      drinks,
      tableTypes,
      drinksConfig,
      tablesConfig,
      drinkPricesToSubmit,
      tablesToSubmit,
      visibleAddDrinkPrices,
      visibleAddTables,
      showAlert,
      alert,
    } = this.state;
    return (
      <div>
        {showAlert && (
          <Alert
            message={alert.message}
            description={alert.description}
            type={alert.type}
            showIcon
            closable
            onClose={() => this.setState({ showAlert: false })}
          />
        )}
        <Button type="primary" onClick={this.showDrinksDrawer}>
          <PlusOutlined /> Add Drink Prices
        </Button>
        <Button type="primary" onClick={this.showTablesDrawer}>
          <PlusOutlined /> Add Tables
        </Button>
        <FormikForm
          config={clubConfig}
          submitHandler={this.clubSubmitHandler}
        />
        <Button type="primary" onClick={this.submitClub}>
          Save Club
        </Button>
        <Drawer
          title="Add Drink Prices"
          width={720}
          onClose={this.onClose}
          visible={visibleAddDrinkPrices}
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
              {/* <Button onClick={this.onClose} type="primary">
                Submit
              </Button> */}
            </div>
          }
        >
          <FormikForm
            config={drinksConfig}
            submitHandler={this.drinksSubmitHandler}
          />
        </Drawer>
        <Drawer
          title="Add Tables"
          width={720}
          onClose={this.onClose}
          visible={visibleAddTables}
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
              {/* <Button onClick={this.onClose} type="primary">
                Submit
              </Button> */}
            </div>
          }
        >
          <FormikForm
            config={tablesConfig}
            submitHandler={this.tablesSubmitHandler}
          />
        </Drawer>
      </div>
    );
  }
}

export default ClubComponent;