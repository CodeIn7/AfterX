import { combineReducers } from 'redux';
import { UserReducer } from './user_reducer';
import {
  reservationsListReducer,
  reservationDeleteReducer,
  reservationSaveReducer,
} from './reservations_reducer';
import { clubsListReducer, clubsTablesReducer } from './clubs_reducer';

const rootReducer = combineReducers({
  user: UserReducer,
  reservations: reservationsListReducer,
  reservationDelete: reservationDeleteReducer,
  clubs: clubsListReducer,
  tables: clubsTablesReducer,
  savedRes: reservationSaveReducer,
});

export default rootReducer;
