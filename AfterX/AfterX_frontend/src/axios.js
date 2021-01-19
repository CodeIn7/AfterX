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

axios.interceptors.request.use(
  async (config) => {
    const user = localStorage.getItem('currentUser');
    const { token } = user;
    config.headers.authorization = `Bearer ${token}`;
    const decodedToken = jwt.decode(token, { complete: true });
    console.log(decodedToken);
    // const tokenDate = new Date(decodedToken.payload.exp * 1000);
    // const currentDate = new Date();
    // if (tokenDate.getTime() <= currentDate.getTime()) {
    //   await axios
    //     .post(
    //       `${RELATIVE_URL}refresh?refreshToken=${localStorage.getItem(
    //         'refreshToken'
    //       )}`
    //     )
    //     .then((res) => {
    //       AuthenticationService.registerSuccessfulLoginForJwt(
    //         res.data.userAttribute.userName,
    //         res.data.accessToken,
    //         res.data.refreshToken
    //       );
    //       config.headers.authorization = `Bearer ${res.data.accessToken}`;
    //     })
    //     .catch((err) => {
    //       window.location.href = '/odjava/invalidsession';
    //     });
    // };
    return config;
  },
  (error) => Promise.reject(error)
);

// instance.defaults.headers.common.Authorization = 'AUTH TOKEN FROM INSTANCE';
export default instance;
