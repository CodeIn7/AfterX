import { BehaviorSubject } from 'rxjs';
// eslint-disable-next-line import/no-cycle
import jwt from 'jsonwebtoken';
import { handleResponse } from '../_helpers/handle-response';
import axios from '../axios';

const currentUserSubject = new BehaviorSubject(
  JSON.parse(localStorage.getItem('currentUser'))
);
// const tokenSubject = new BehaviorSubject(
//   JSON.parse(localStorage.getItem('token'))
// );
export function login(email, password) {
  // const requestOptions = {
  //   method: 'POST',
  //   headers: { 'Content-Type': 'application/json' },
  //   body: JSON.stringify({ email, password }),
  // };

  return (
    axios
      .post(`/idnetity/login`, { email, password })
      // .then(handleResponse)
      .then((response) => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        const { token } = response.data;
        const decodedToken = jwt.decode(token, { complete: true });
        const { payload } = decodedToken;
        const userId = payload.id;
        // const currentUserEmail
        localStorage.setItem('currentUser', JSON.stringify(token));
        console.log(decodedToken);
        currentUserSubject.next(token);

        return token;
      })
  );
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
