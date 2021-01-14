import * as types from '../_actions/types';

function clubsListReducer(state = { clubs: [] }, { type, payload }) {
  switch (type) {
    case types.CLUBS_LIST_REQUEST:
      return { loading: true, clubs: [] };
    case types.CLUBS_LIST_SUCCESS:
      return { loading: false, clubs: payload };
    case types.CLUBS_LIST_FAIL:
      return { loading: false, error: payload };
    default:
      return state;
  }
}
function clubsTablesReducer(state = { tables: [] }, { type, payload }) {
  switch (type) {
    case types.FREETABLES_LIST_REQUEST:
      return { loading: true, tables: [] };
    case types.FREETABLES_LIST_SUCCESS:
      return { loading: false, tables: payload };
    case types.FREETABLES_LIST_FAIL:
      return { loading: false, error: payload };
    default:
      return state;
  }
}
export { clubsListReducer, clubsTablesReducer };
