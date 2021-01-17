import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import PropType from 'prop-types';
import { Formik } from 'formik';
import * as Yup from 'yup';
import { Form, Icon, Input, Button, Checkbox, Typography } from 'antd';
import jwt from 'jsonwebtoken';
import './LoginPage.css';
import axios from '../../../axios';
import {
  currentUserValue,
  login,
} from '../../../_services/authentication.service';

const { Title } = Typography;

class LoginPage extends Component {
  constructor(props) {
    super(props);
    this.state = {};
    if (currentUserValue) {
      // eslint-disable-next-line react/destructuring-assignment
      this.props.history.push('/');
    }
  }

  componentDIdMount = () => {
    // const token = JSON.parse(localStorage.getItem('token'));
  };

  render() {
    const { history, location } = this.props;
    return (
      <>
        <Formik
          initialValues={{
            email: '',
            password: '',
          }}
          validationSchema={Yup.object().shape({
            email: Yup.string()
              .email('Email is invalid')
              .required('Email is required'),
            password: Yup.string()
              .min(6, 'Password must be at least 6 characters')
              .required('Password is required'),
          })}
          onSubmit={({ email, password }, { setStatus, setSubmitting }) => {
            setStatus();
            login(email, password).then(
              // (user) => {
              () => {
                const { from } = location.state || {
                  from: { pathname: '/' },
                };
                history.push(from);
              },
              (error) => {
                setSubmitting(false);
                setStatus(error);
              }
            );
          }}
        >
          {(_props) => {
            const {
              values,
              touched,
              errors,
              // dirty,
              isSubmitting,
              handleChange,
              handleBlur,
              handleSubmit,
              // handleReset,
            } = _props;
            return (
              <div className="app">
                <Title style={{ color: 'white' }} level={2}>
                  Log In
                </Title>
                <form onSubmit={handleSubmit} style={{ width: '350px' }}>
                  <Form.Item required>
                    <Input
                      id="email"
                      prefix={
                        <Icon
                          type="user"
                          style={{ color: 'rgba(0,0,0,.25)' }}
                        />
                      }
                      placeholder="Enter your email"
                      type="email"
                      value={values.email}
                      onChange={handleChange}
                      onBlur={handleBlur}
                      className={
                        errors.email && touched.email
                          ? 'text-input error'
                          : 'text-input'
                      }
                    />
                    {errors.email && touched.email && (
                      <div className="input-feedback">{errors.email}</div>
                    )}
                  </Form.Item>

                  <Form.Item required>
                    <Input
                      id="password"
                      prefix={
                        <Icon
                          type="lock"
                          style={{ color: 'rgba(0,0,0,.25)' }}
                        />
                      }
                      placeholder="Enter your password"
                      type="password"
                      value={values.password}
                      onChange={handleChange}
                      onBlur={handleBlur}
                      className={
                        errors.password && touched.password
                          ? 'text-input error'
                          : 'text-input'
                      }
                    />
                    {errors.password && touched.password && (
                      <div className="input-feedback">{errors.password}</div>
                    )}
                  </Form.Item>

                  {/* formErrorMessage && (
                  // eslint-disable-next-line jsx-a11y/label-has-associated-control
                  <label>
                    <p
                      style={{
                        color: '#ff0000bf',
                        fontSize: '0.7rem',
                        border: '1px solid',
                        padding: '1rem',
                        borderRadius: '10px',
                      }}
                    >
                      {formErrorMessage}
                    </p>
                  </label>
                ) */}

                  <Form.Item>
                    <Checkbox
                      id="rememberMe"
                      style={{ color: 'white' }}
                      // onChange={handleRememberMe}
                      // checked={rememberMe}
                    >
                      Remember me
                    </Checkbox>
                    <a
                      className="login-form-forgot"
                      href="/reset_user"
                      style={{
                        float: 'right',
                        color: 'black',
                        fontFamily: 'Georgia',
                        fontDecoration: 'underline',
                      }}
                    >
                      <span className="forgotPassLink">forgot password?</span>
                    </a>
                    <div>
                      <Button
                        type="primary"
                        htmlType="submit"
                        className="login-form-button"
                        style={{ minWidth: '100%' }}
                        disabled={isSubmitting}
                        onSubmit={handleSubmit}
                      >
                        Log in
                      </Button>
                    </div>
                    <div style={{ fontFamily: 'Georgia', color: 'white' }}>
                      Or{' '}
                      <a
                        className="registerLink"
                        style={{ fontFamily: 'Georgia' }}
                        href="/register"
                      >
                        register now!
                      </a>
                    </div>
                  </Form.Item>
                </form>
              </div>
            );
          }}
        </Formik>
      </>
    );
  }
}
LoginPage.propTypes = {
  history: PropType.any,
  location: PropType.any,
};
export default withRouter(LoginPage);
