/* eslint-disable react/jsx-props-no-spreading */
import React, { Component } from 'react';
import moment from 'moment';
import { Formik } from 'formik';
import * as Yup from 'yup';
import 'antd/dist/antd.css';
import { Form, Input, Row, Col, Button, Radio, DatePicker } from 'antd';
import { register } from '../../../_services/authentication.service';

const formItemLayout = {
  labelCol: {
    xs: { span: 24 },
    sm: { span: 8 },
  },
  wrapperCol: {
    xs: { span: 24 },
    sm: { span: 16 },
  },
};
const tailFormItemLayout = {
  wrapperCol: {
    xs: {
      span: 24,
      offset: 0,
    },
    sm: {
      span: 16,
      offset: 0,
    },
  },
};

const registrationValues = {
  role: '',
  email: '',
  lastName: '',
  firstName: '',
  password: '',
  confirmPassword: '',
  gender: '',
  birthDate: '',
  telephone: '',
};
const validationSchema = Yup.object().shape({
  firstName: Yup.string().required('First Name is required'),
  lastName: Yup.string().required('Last Name is required'),
  email: Yup.string().email('Email is invalid').required('Email is required'),
  password: Yup.string()
    .min(6, 'Password must be at least 6 characters')
    .required('Password is required'),
  confirmPassword: Yup.string()
    .oneOf([Yup.ref('password'), null], 'Passwords must match')
    .required('Confirm Password is required'),
});
class RegisterPage extends Component {
  constructor(props) {
    super(props);
    this.state = {
      gender: null,
      birthDate: new Date(),
      roleName: null,
    };
  }

  registerUser = (registrationData, _callback) => {
    register(registrationData, _callback);
  };

  render() {
    const { gender, birthDate, roleName } = this.state;
    return (
      <Formik
        initialValues={{ ...registrationValues }}
        validationSchema={validationSchema}
        onSubmit={(values, { setSubmitting }) => {
          setTimeout(() => {
            const registrationData = {
              email: values.email,
              password: values.password,
              firstName: values.firstName,
              lastname: values.lastName,
              telephone: values.telephone,
              gender: gender === 1 ? 'M' : 'F',
              roleName: roleName === 1 ? 'BARTENDER' : 'USER',
              birthDate,
              image: `http://gravatar.com/avatar/${moment().unix()}?d=identicon`,
            };
            console.log(registrationData);
            this.registerUser(registrationData, () => setSubmitting(false));
          }, 500);
        }}
      >
        {(props) => {
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
          } = props;
          return (
            <Row justify="center">
              <Col span={24}>
                <h2 style={{ color: 'white' }}>Sign up</h2>
              </Col>
              <Col span={18}>
                <Form
                  justify="center"
                  layout="horizontal"
                  wrapperCol={{
                    span: 24,
                  }}
                  style={{ width: '100%' }}
                  // eslint-disable-next-line react/jsx-props-no-spreading
                  {...formItemLayout}
                  onSubmit={handleSubmit}
                >
                  <Form.Item justify="center">
                    <Radio.Group
                      onChange={(e) =>
                        this.setState({ roleName: e.target.value })
                      }
                      value={roleName}
                    >
                      <Radio value={1}>
                        <span style={{ color: 'white' }}>Bartender</span>
                      </Radio>
                      <Radio value={2}>
                        <span style={{ color: 'white' }}>Customer</span>
                      </Radio>
                    </Radio.Group>
                  </Form.Item>

                  <Form.Item required justify="center">
                    <Input
                      style={{ width: '100%' }}
                      id="firstName"
                      placeholder="Enter your First Name"
                      type="text"
                      value={values.firstName}
                      onChange={handleChange}
                      onBlur={handleBlur}
                      className={
                        errors.firstName && touched.firstName
                          ? 'text-input error'
                          : 'text-input'
                      }
                    />
                    {errors.firstName && touched.firstName && (
                      <div className="input-feedback">{errors.firstName}</div>
                    )}
                  </Form.Item>

                  <Form.Item required justify="center">
                    <Input
                      id="lastName"
                      placeholder="Enter your Last Name"
                      type="text"
                      value={values.lastName}
                      onChange={handleChange}
                      onBlur={handleBlur}
                      className={
                        errors.lastName && touched.lastName
                          ? 'text-input error'
                          : 'text-input'
                      }
                    />
                    {errors.lastName && touched.lastName && (
                      <div className="input-feedback">{errors.lastName}</div>
                    )}
                  </Form.Item>

                  <Form.Item justify="center">
                    <Radio.Group
                      onChange={(e) =>
                        this.setState({ gender: e.target.value })
                      }
                      value={gender}
                    >
                      <Radio value={1}>
                        <span style={{ color: 'white' }}>M</span>
                      </Radio>
                      <Radio value={2}>
                        <span style={{ color: 'white' }}>F</span>
                      </Radio>
                    </Radio.Group>
                  </Form.Item>

                  <Form.Item justify="center">
                    <DatePicker
                      style={{ width: '100%' }}
                      id="birthDate"
                      placeholder="Select birth date"
                      selected={birthDate}
                      onChange={(date, stringDate) =>
                        this.setState({ birthDate: stringDate })
                      }
                    />
                  </Form.Item>
                  <Form.Item required justify="center">
                    <Input
                      id="telephone"
                      placeholder="Enter your phone number"
                      type="text"
                      value={values.telephone}
                      onChange={handleChange}
                      onBlur={handleBlur}
                      className={
                        errors.telephone && touched.telephone
                          ? 'text-input error'
                          : 'text-input'
                      }
                    />
                    {errors.telephone && touched.telephone && (
                      <div className="input-feedback">{errors.telephone}</div>
                    )}
                  </Form.Item>

                  <Form.Item
                    justify="center"
                    required
                    hasFeedback
                    validateStatus={
                      errors.email && touched.email ? 'error' : 'success'
                    }
                  >
                    <Input
                      id="email"
                      placeholder="Enter your Email"
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

                  <Form.Item
                    justify="center"
                    required
                    hasFeedback
                    validateStatus={
                      errors.password && touched.password ? 'error' : 'success'
                    }
                  >
                    <Input
                      id="password"
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

                  <Form.Item required hasFeedback justify="center">
                    <Input
                      id="confirmPassword"
                      placeholder="Confirm your password"
                      type="password"
                      value={values.confirmPassword}
                      onChange={handleChange}
                      onBlur={handleBlur}
                      className={
                        errors.confirmPassword && touched.confirmPassword
                          ? 'text-input error'
                          : 'text-input'
                      }
                    />
                    {errors.confirmPassword && touched.confirmPassword && (
                      <div className="input-feedback">
                        {errors.confirmPassword}
                      </div>
                    )}
                  </Form.Item>

                  <Form.Item justify="center" {...tailFormItemLayout}>
                    <Button
                      onClick={handleSubmit}
                      type="primary"
                      disabled={isSubmitting}
                    >
                      Submit
                    </Button>
                  </Form.Item>
                </Form>
              </Col>
            </Row>
          );
        }}
      </Formik>
    );
  }
}

export default RegisterPage;
