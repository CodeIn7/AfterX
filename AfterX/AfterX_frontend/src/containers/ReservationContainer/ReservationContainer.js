import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Route, Switch } from 'react-router-dom';
import ReservationListComponent from './ReservationListComponent';

function ReservationContainer({ match }) {
  const { path } = match;
  return (
    <Switch>
      <Route exact path={path} component={ReservationListComponent} />
      {/* <Route path={`${path}/add`} component={AddEdit} /> */}
      {/* <Route path={`${path}/edit/:id`} component={AddEdit} /> */}
    </Switch>
  );
}

ReservationContainer.propTypes = {
  path: PropTypes.any,
};

export default ReservationContainer;
