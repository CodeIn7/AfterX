import React from 'react';
import { Route, Switch } from 'react-router-dom';
import PropTypes from 'prop-types';
import List from './List';
import AddEdit from './AddEdit';

function DrinkContainer({ match }) {
  const { path } = match;
  return (
    <Switch>
      <Route exact path={path} component={List} />
      <Route path={`${path}/add`} component={AddEdit} />
      <Route path={`${path}/edit/:id`} component={AddEdit} />
    </Switch>
  );
}

DrinkContainer.propTypes = {
  match: PropTypes.any,
};

export default DrinkContainer;
