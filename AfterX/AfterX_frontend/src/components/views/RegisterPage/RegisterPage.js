/* eslint-disable react/jsx-props-no-spreading */
import React, { useState } from 'react';
import moment from 'moment';
import { Formik } from 'formik';
import * as Yup from 'yup';
import { useDispatch } from 'react-redux';
import 'antd/dist/antd.css';
import { Form, Input, Button, Radio, DatePicker } from 'antd';
import { registerUser } from '../../../_actions/user_actions';

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
      offset: 8,
    },
  },
};

function RegisterPage() {
  const dispatch = useDispatch();
  const [gender, setGender] = useState(1);
  const [birtDate, setBirthDate] = useState(new Date());
  return (
    <Formik
      initialValues={{
        email: '',
        lastName: '',
        name: '',
        password: '',
        confirmPassword: '',
        gender,
        birthDate: '',
        telephone: '',
      }}
      validationSchema={Yup.object().shape({
        name: Yup.string().required('Name is required'),
        lastName: Yup.string().required('Last Name is required'),
        email: Yup.string()
          .email('Email is invalid')
          .required('Email is required'),
        password: Yup.string()
          .min(6, 'Password must be at least 6 characters')
          .required('Password is required'),
        confirmPassword: Yup.string()
          .oneOf([Yup.ref('password'), null], 'Passwords must match')
          .required('Confirm Password is required'),
      })}
      onSubmit={(values, { setSubmitting }) => {
        setTimeout(() => {
          const dataToSubmit = {
            email: values.email,
            password: values.password,
            name: values.name,
            lastname: values.lastname,
            telephone: values.telephone,
            gender: gender === 1 ? 'M' : 'F',
            birthDate: birtDate,
            image: `http://gravatar.com/avatar/${moment().unix()}?d=identicon`,
          };

          dispatch(registerUser(dataToSubmit)).then((response) => {
            if (response.payload.success) {
              window.location.href = 'http://localhost:3000/login';
            } else {
              alert(response.payload.err.errmsg);
            }
          });

          setSubmitting(false);
        }, 500);
      }}
    >
      {(
        values,
        touched,
        errors,
        dirty,
        isSubmitting,
        handleChange,
        handleBlur,
        handleSubmit
        // handleReset
      ) => (
        <div className="app">
          <h2 style={{ color: 'white' }}>Sign up</h2>
          <Form
            style={{ minWidth: '375px' }}
            // eslint-disable-next-line react/jsx-props-no-spreading
            {...formItemLayout}
            onSubmit={handleSubmit}
          >
            <Form.Item required>
              <Input
                id="name"
                placeholder="Enter your name"
                type="text"
                value={values.name}
                onChange={handleChange}
                onBlur={handleBlur}
                className={
                  errors.name && touched.name
                    ? 'text-input error'
                    : 'text-input'
                }
              />
              {errors.name && touched.name && (
                <div className="input-feedback">{errors.name}</div>
              )}
            </Form.Item>

            <Form.Item required>
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

            <Form.Item>
              <Radio.Group
                style={{ marginLeft: '120px' }}
                onChange={(e) => setGender(e.target.value)}
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

            <Form.Item>
              <DatePicker
                id="birthDate"
                placeholder="Select date"
                selected={birtDate}
                onChange={(date) => setBirthDate(date)}
              />
            </Form.Item>
            {/* <Form.Item required >
                <Input
                  id="telephone"
                  placeholder="Enter your phone number"
                  type="text"
                  value={values.telephone}
                  onChange={handleChange}
                  onBlur={handleBlur}
                  className={
                    errors.telephone && touched.telephone ? 'text-input error' : 'text-input'
                  }
                />
                {errors.telephone && touched.telephone && (
                  <div className="input-feedback">{errors.telephone}</div>
                )}
              </Form.Item> */}

            <Form.Item
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

            <Form.Item required hasFeedback>
              <Input
                id="confirmPassword"
                placeholder="Enter your confirmPassword"
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
                <div className="input-feedback">{errors.confirmPassword}</div>
              )}
            </Form.Item>

            <Form.Item {...tailFormItemLayout}>
              <Button
                onClick={handleSubmit}
                style={{ marginLeft: '34px' }}
                type="primary"
                disabled={isSubmitting}
              >
                Submit
              </Button>
            </Form.Item>
          </Form>
        </div>
      )}
    </Formik>
  );
}

export default RegisterPage;
