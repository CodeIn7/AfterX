import { BehaviorSubject } from 'rxjs';
// eslint-disable-next-line import/no-cycle
import jwt from 'jsonwebtoken';
// import { handleResponse } from '../_helpers/handle-response';
import axios from '../axios';

const currentUserSubject = new BehaviorSubject(
  JSON.parse(localStorage.getItem('currentUser'))
);
function storeToken(response) {
  const { token } = response.data;
  const decodedToken = jwt.decode(token, { complete: true });
  const { payload } = decodedToken;
  const userData = {
    userId: payload.id,
    firstname: payload.Firstname,
    lastname: payload.Lastname,
    email: payload.email,
    role: payload.role,
    token,
  };

  // const currentUserEmail
  localStorage.setItem('currentUser', JSON.stringify(userData));

  currentUserSubject.next(userData);
}
export function login(email, password, _callback) {
  axios
    .post(`/idnetity/login`, { email, password })
    // .then(handleResponse)
    .then((response) => {
      storeToken(response);
      _callback();
    })
    .catch(() => {
      _callback();
    });
}

export function register(registrationData, _callback) {
  axios
    .post('/idnetity/register', registrationData)
    .then((response) => {
      console.log(response.data.token);
      alert(`token: ${response.data.token}`);
      storeToken(response);
      _callback();
    })
    .catch(() => {
      _callback();
    });
}

export function logout() {
  // remove user from local storage to log user out
  localStorage.removeItem('currentUser');
  currentUserSubject.next(null);
}
export const currentUserValue = currentUserSubject.value;
export const currentUser = currentUserSubject.asObservable();
// const authenticationService = {
//   login,
//   logout,
//   currentUser: currentUserSubject.asObservable(),
//   get currentUserValue() {
//     return currentUserSubject.value;
//   },
// };
// export default authenticationService;
