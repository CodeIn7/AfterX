import axios from 'axios';
import jwt from 'jsonwebtoken';

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

instance.interceptors.request.use(
  async (config) => {
    const user = localStorage.getItem('currentUser');
    if (user) {
      const { token } = JSON.parse(user);
      config.headers.authorization = `Bearer ${token}`;
      const decodedToken = jwt.decode(token, { complete: true });
    }
    return config;
  },
  (error) => Promise.reject(error)
);

// instance.defaults.headers.common.Authorization = 'AUTH TOKEN FROM INSTANCE';
export default instance;
