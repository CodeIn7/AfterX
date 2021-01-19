import React, { Suspense } from 'react';
import { Route, Switch, withRouter } from 'react-router-dom';
// import Auth from '../hoc/auth';
import LandingPage from './views/LandingPage/LandingPage.js';
import BartenderLandingPage from './views/BartenderLandingPage/BartenderLandingPage.js';
import BartenderLogin from './views/BartenderLogin/BartenderLogin';
import BartenderRegister from './views/BartenderRegister/BartenderRegister';
import UserLandingPage from './views/UserLandingPage/UserLandingPage';
import CustomChatbot from './chatbot/CustomChatbot';
import { currentUser, logout } from '../_services/authentication.service';
import { HomePage } from '../HomePage';
import { PrivateRoute } from './PrivateRoute/PrivateRoute';
// null   Anyone Can go inside
// true   only logged in user can go inside
// false  logged in user can't go inside

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

  logout() {
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
              <a onClick={this.logout} className="nav-item nav-link">
                Logout
              </a>
            </div>
          </nav>
        ) : null}
        <div style={{ paddingTop: '0px', minHeight: 'calc(100vh - 80px)', overflowX: 'hidden', overflowY: 'hidden'}}>
          <Switch>
            {/* <Route exact path="/" component={Auth(LandingPage, null)} /> */}
            <Route exact path="/" component={LandingPage} />
            <Route
              exact
              path="/BartenderLanding"
              component={BartenderLandingPage}
              //  component={Auth(BartenderLandingPage, true)}
            />
            {/* <Route exact path="/login" component={Auth(BartenderLogin, null)} /> */}
            <Route exact path="/login" component={BartenderLogin} />
            {/* <Route exact path="/User" component={Auth(UserLandingPage, null)} /> */}
            <Route exact path="/user" component={UserLandingPage} />
            <Route
              exact
              path="/register"
              // component={Auth(BartenderRegister, null)}
              component={BartenderRegister}
            />
            <PrivateRoute exact path="/home" component={HomePage} />
          </Switch>
          <CustomChatbot />
        </div>
      </Suspense>
    );
  }
}

export default withRouter(App);
