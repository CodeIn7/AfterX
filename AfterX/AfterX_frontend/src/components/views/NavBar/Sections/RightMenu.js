/* eslint-disable jsx-a11y/anchor-is-valid */
import React from 'react';
import PropType from 'prop-types';
import { Menu } from 'antd';
import axios from 'axios';
import { withRouter } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { USER_SERVER } from '../../../Config';

function RightMenu(props) {
  const { mode } = props;
  const user = useSelector((state) => state.user);

  const logoutHandler = () => {
    axios.get(`${USER_SERVER}/logout`).then((response) => {
      if (response.status === 200) {
        props.history.push('/login');
      } else {
        alert('Log Out Failed');
      }
    });
  };

  if (user.userData && !user.userData.isAuth) {
    return (
      <Menu mode={mode}>
        {/* <Menu.Item key="mail">
          <a href="/login">Signin</a>
        </Menu.Item>
        <Menu.Item key="app">
          <a href="/register">Signup</a>
        </Menu.Item> */}
      </Menu>
    );
  }
  return (
    <Menu mode={mode}>
      <Menu.Item key="logout" onClick={logoutHandler}>
        Logout
      </Menu.Item>
    </Menu>
  );
}
RightMenu.propTypes = {
  history: PropType.any,
  mode: PropType.any,
};
export default withRouter(RightMenu);
