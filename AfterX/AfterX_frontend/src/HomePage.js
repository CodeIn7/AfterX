import React from 'react';
import { currentUser } from './_services/authentication.service';
import axios from './axios';

class HomePage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      data: null,
      user: currentUser,
    };
  }

  componentDidMount() {
    axios.get('/cities/3').then((response) => {
      this.setState({ data: response.data });
    });
  }

  render() {
    const { data, user } = this.state;
    return (
      <div>
        <h1>Hi {user}!</h1>
        Data:{data}
        <h3>--</h3>
        token:{localStorage.getItem('token')}
        <h3>--</h3>
        currentUser:{user}
        <h3>--</h3>
      </div>
    );
  }
}

export { HomePage };
