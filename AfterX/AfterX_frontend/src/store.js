import { createStore, applyMiddleware, compose } from 'redux';

import promiseMiddleware from 'redux-promise';
import ReduxThunk from 'redux-thunk';
import Reducer from './_reducers';

const initialState = {};
const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const store = createStore(
  Reducer,
  initialState,
  composeEnhancer(applyMiddleware(promiseMiddleware, ReduxThunk))
);
export default store;
// const createStoreWithMiddleware = applyMiddleware(promiseMiddleware, ReduxThunk)(createStore);
// store={createStoreWithMiddleware(
//     Reducer,
//     window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
// )}
