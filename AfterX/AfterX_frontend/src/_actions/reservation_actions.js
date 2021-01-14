import axios from 'axios';
import * as types from './types';

const listReservations = (clubId) => async (dispatch) => {
  try {
    dispatch({ type: types.RESERVATIONS_LIST_REQUEST });
    axios.get(`api/reservations/club/${clubId}`).then((res) => {
      dispatch({ type: types.RESERVATIONS_LIST_SUCCESS, payload: res.data });
    });
  } catch (error) {
    dispatch({ type: types.RESERVATIONS_LIST_FAIL, payload: error.message });
  }
};

const deleteReservation = (reservationId) => async (dispatch) => {
  try {
    dispatch({
      type: types.RESERVATION_DELETE_REQUEST,
      payload: reservationId,
    });
    axios.delete(`api/reservations/${reservationId}/delete `).then((res) => {
      dispatch({
        type: types.RESERVATION_DELETE_SUCCESS,
        payload: res.data,
        success: true,
      });
    });
  } catch (error) {
    dispatch({ type: types.RESERVATION_DELETE_FAIL, payload: error.message });
  }
};

export { listReservations, deleteReservation };
