/* eslint-disable react/state-in-constructor */
import React from 'react';
import { Formik } from 'formik';
import { Form, Input, Button, Row, Col } from 'antd';
import PropTypes from 'prop-types';
import { getYupSchemaFromMetaData } from '../../_helpers/yupSchemaCreator';
import './FormikForm.css';

const layout = {
  labelCol: {
    span: 24,
  },
  wrapperCol: {
    span: 24,
  },
};

const FormikForm = (props) => {
  const { config } = props;
  const validationSchema = getYupSchemaFromMetaData(config, [], []);
  const form = config.map((obj) => {
    obj.value = '';
    return obj;
  });

  return (
    <>
      <Formik
        initialValues={{}}
        validationSchema={validationSchema}
        onSubmit={async (values, { setSubmitting }) => {
          await new Promise((r) => setTimeout(r, 500));
          props.submitHandler(values);
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
              <Form {...layout} style={{ width: '100%', padding: '3%' }}>
                <div>
                  {form.map((individualConfig) => {
                    const { field } = individualConfig;
                    return (
                      <Form.Item
                        key={field}
                        label={individualConfig.label}
                        className="myLabel"
                        style={{ color: 'white' }}
                      >
                        <Input
                          type={individualConfig.type}
                          name={field}
                          onChange={(e) => {
                            handleChange(e);
                          }}
                          style={{
                            margin: '10px',
                          }}
                          id={field}
                          placeholder={individualConfig.placeholder}
                          className={
                            errors[field] && touched[field]
                              ? 'text-input error'
                              : 'text-input'
                          }
                        />
                        {errors[field] && touched[field] && (
                          <div className="input-feedback">{errors[field]}</div>
                        )}
                      </Form.Item>
                    );
                  })}
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
    </>
  );
};
FormikForm.propTypes = {
  config: PropTypes.array,
  submitHandler: PropTypes.func,
};
export default FormikForm;
