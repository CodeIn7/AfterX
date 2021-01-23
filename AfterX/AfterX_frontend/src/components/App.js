import React, { Suspense } from 'react';
import { Router, Route, Switch, withRouter } from 'react-router-dom';
// import Auth from '../hoc/auth';
import LandingPage from './views/LandingPage/LandingPage.js';
import BartenderLandingPage from './views/BartenderLandingPage/BartenderLandingPage.js';
import BartenderLogin from './views/BartenderLogin/BartenderLogin';
import BartenderRegister from './views/BartenderRegister/BartenderRegister';
import UserLandingPage from './views/UserLandingPage/UserLandingPage';
import CustomChatbot from './chatbot/CustomChatbot';
import { currentUser, logout } from '../_services/authentication.service';
import { PrivateRoute } from './PrivateRoute/PrivateRoute';
import DrinkContainer from '../containers/DrinkContainer/DrinkContainer.js';
import ClubContainer from '../containers/ClubContainer/ClubContainer';
import { createBrowserHistory } from 'history';
// null   Anyone Can go inside
// true   only logged in user can go inside
// false  logged in user can't go inside
const history = createBrowserHistory();

class App extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      currentUser: null,
    };
  }

  componentDidMount() {
    currentUser.subscribe((x) => this.setState({ currentUser: x }));
  }

  _logout() {
    logout();
    // this.props.history.push('/login');
  }

  render() {
    const { currentUser } = this.state;
    return (
      <Suspense fallback={<div>Loading...</div>}>
        {currentUser ? (
          <nav className="navbar navbar-expand navbar-dark bg-dark">
            <div className="navbar-nav">
              <button onClick={this._logout} className="nav-item nav-link">
                Logout
              </button>
            </div>
          </nav>
        ) : null}
        <div style={{ paddingTop: '0px', minHeight: 'calc(100vh - 80px)' }}>
          <Switch>
            <Route exact path="/" component={LandingPage} />
            <Route
              exact
              path="/BartenderLanding"
              component={BartenderLandingPage}
            />
            <Route exact path="/login" component={BartenderLogin} />
            <Route exact path="/User" component={UserLandingPage} />
            <Route exact path="/register" component={BartenderRegister} />
            <PrivateRoute exact path="/drinks" component={DrinkContainer} />
            <PrivateRoute exact path="/clubs" component={ClubContainer} />
          </Switch>
          <CustomChatbot />
        </div>
      </Suspense>
    );
  }
}

export default withRouter(App);
