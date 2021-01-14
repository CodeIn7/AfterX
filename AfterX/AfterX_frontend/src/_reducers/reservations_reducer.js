import * as types from '../_actions/types';

function reservationsListReducer(
  state = { reservations: [] },
  { type, payload }
) {
  switch (type) {
    case types.RESERVATIONS_LIST_REQUEST:
      return { loading: true, reservations: [] };
    case types.RESERVATIONS_LIST_SUCCESS:
      return { loading: false, reservations: payload };
    case types.RESERVATIONS_LIST_FAIL:
      return { loading: false, error: payload };
    default:
      return state;
  }
}
function reservationSaveReducer(state = { save: {} }, { type, payload }) {
  switch (type) {
    case types.POST_RESERVATION_REQUEST:
      return { loading: true };
    case types.POST_RESERVATION_SUCCESS:
      return { loading: false, success: true, save: payload };
    case types.POST_RESERVATION_FAIL:
      return { loading: false, error: payload };
    default:
      return state;
  }
}

function reservationDeleteReducer(
  state = { reservation: {} },
  { type, payload }
) {
  switch (type) {
    case types.RESERVATION_DELETE_REQUEST:
      return { loading: true };
    case types.RESERVATION_DELETE_SUCCESS: {
      return { loading: false, userClub: payload, success: true };
    }
    case types.RESERVATION_DELETE_FAIL:
      return { loading: false, error: payload };
    default:
      return state;
  }
}
export {
  reservationsListReducer,
  reservationDeleteReducer,
  reservationSaveReducer,
};
