import 'react-app-polyfill/ie9';
import 'react-app-polyfill/ie11';
import 'core-js';

import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { BrowserRouter } from 'react-router-dom';
import { createBrowserHistory } from 'history';
import App from './components/App';
import * as serviceWorker from './serviceWorker';

const history = createBrowserHistory();

ReactDOM.render(
  <BrowserRouter history={history}>
    <App />
  </BrowserRouter>,
  document.getElementById('root')
);
serviceWorker.unregister();
