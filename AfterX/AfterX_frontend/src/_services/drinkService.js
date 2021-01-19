import axios from '../axios';

const baseUrl = '/drinks';

function getAll(_callback) {
  axios.get(baseUrl).then((response) => {
    _callback && _callback(response);
    return response.data;
  });
}

// function getById(id) {
//   return fetchWrapper.get(`${baseUrl}/${id}`);
// }

// function create(params) {
//   return fetchWrapper.post(baseUrl, params);
// }

// function update(id, params) {
//   return fetchWrapper.put(`${baseUrl}/${id}`, params);
// }

// // prefixed with underscored because delete is a reserved word in javascript
// function _delete(id) {
//   return fetchWrapper.delete(`${baseUrl}/${id}`);
// }
export const drinkService = {
  getAll,
  //   getById,
  //   create,
  //   update,
  //   delete: _delete,
};
