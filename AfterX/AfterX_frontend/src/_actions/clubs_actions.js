import axios from 'axios';
import * as types from './types';

const listClubs = () => async (dispatch) => {
  try {
    dispatch({ type: types.CLUBS_LIST_REQUEST });
    axios.get('api/clubs').then((res) => {
      dispatch({ type: types.CLUBS_LIST_SUCCESS, payload: res.data });
    });
  } catch (error) {
    dispatch({ type: types.CLUBS_LIST_FAIL, payload: error.message });
  }
};
const listClubFreeTables = (clubId) => async (dispatch) => {
  try {
    dispatch({ type: types.FREETABLES_LIST_REQUEST });

    axios.get(`api/tables/club/${clubId}`).then((res) => {
      dispatch({ type: types.FREETABLES_LIST_SUCCESS, payload: res.data });
    });
  } catch (error) {
    dispatch({ type: types.FREETABLES_LIST_FAIL, payload: error.message });
  }
};
const submitNewReservation = (data) => (dispatch) => {
  try {
    dispatch({ type: types.POST_RESERVATION_REQUEST });
    axios.post('api/reservations/create', data).then((res) => {
      dispatch({
        type: types.POST_RESERVATION_SUCCESS,
        payload: res.data,
        success: true,
      });
      console.log(res.data);
    });
  } catch (error) {
    dispatch({ type: types.POST_RESERVATION_FAIL, payload: error.message });
  }
};
export { listClubs, listClubFreeTables, submitNewReservation };
