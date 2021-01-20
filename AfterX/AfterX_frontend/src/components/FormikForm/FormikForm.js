/* eslint-disable react/state-in-constructor */
import React, { Component } from 'react';
import { Formik } from 'formik';
import { Form, Icon, Input, Button, Checkbox, Typography } from 'antd';
import response from '../../apiresponse';
import { getYupSchemaFromMetaData } from '../../_helpers/yupSchemaCreator';

const FormikForm = (props) => {
  const validationSchema = getYupSchemaFromMetaData(response, [], []);
  console.log(props);
  const form = props.config.map((obj) => {
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
          alert(JSON.stringify(values, null, 2));
          console.log(values);
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
            <Form onSubmit={handleSubmit} style={{ width: '350px' }}>
              Values:{JSON.stringify(values)}
              Errors:{JSON.stringify(errors)}
              <div>
                {form.map((individualConfig) => {
                  const { field } = individualConfig;
                  return (
                    <Form.Item>
                      <label htmlFor={field}>{individualConfig.label}</label>
                      <Input
                        type={individualConfig.type}
                        name={field}
                        onChange={handleChange}
                        style={{ ...individualConfig.style }}
                        id={field}
                        placeholder={individualConfig.label}
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

                <button
                  type="submit"
                  htmlType=""
                  disabled={isSubmitting}
                  onSubmit={handleSubmit}
                >
                  Submit
                </button>
              </div>
            </Form>
          );
        }}
      </Formik>
    </>
  );
};
export default FormikForm;
