import 'react-app-polyfill/ie9';
import 'react-app-polyfill/ie11';
import 'core-js';

import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { Router } from 'react-router-dom';
import { createBrowserHistory } from 'history';
import App from './components/App';
import * as serviceWorker from './serviceWorker';

const history = createBrowserHistory();

ReactDOM.render(
  <Router history={history}>
    <App />
  </Router>,
  document.getElementById('root')
);
serviceWorker.unregister();
