import React, { Component } from 'react';
import PropTypes from 'prop-types';
import ClubComponent from '../../components/ClubComponent/ClubComponent';

export class ClubContainer extends Component {
  //   static propTypes = {};

  render() {
    return (
      <div>
        <ClubComponent />
      </div>
    );
  }
}

export default ClubContainer;
