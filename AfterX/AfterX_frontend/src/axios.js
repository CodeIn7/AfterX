import axios from 'axios';

const instance = axios.create({
  baseURL: 'https://localhost:5001/api/v1',
  headers: {
    'Content-Type': 'application/json, charset=utf-8',
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': 'DELETE, POST, GET,PUT, OPTIONS',
    'Access-Control-Allow-Headers':
      'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
  },
});

axios.interceptors.request.use(
  (request) => {
    console.log(request);
    return request;
  },
  (error) => {
    console.log(error);
  }
);

// instance.defaults.headers.common.Authorization = 'AUTH TOKEN FROM INSTANCE';
export default instance;
