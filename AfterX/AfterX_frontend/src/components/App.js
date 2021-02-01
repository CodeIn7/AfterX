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
import { PrivateRoute } from './PrivateRoute/PrivateRoute';
import DrinkContainer from '../containers/DrinkContainer/DrinkContainer.js';
import ClubContainer from '../containers/ClubContainer/ClubContainer';
import HomeContainer from '../containers/HomeContainer/HomeContainer.js';
import ReservationContainer from '../containers/ReservationContainer/ReservationContainer.js';
import Layout from '../containers/Layout/Layout';
// null   Anyone Can go inside
// true   only logged in user can go inside
// false  logged in user can't go inside

class App extends React.Component {
  render() {
    return (
      // <Layout>
      <Suspense fallback={<div>Loading...</div>}>
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
            <PrivateRoute exact path="/home" component={HomeContainer} />
            <PrivateRoute
              path="/reservations"
              component={ReservationContainer}
            />
          </Switch>
          <CustomChatbot />
        </div>
      </Suspense>
      // </Layout>
    );
  }
}

export default withRouter(App);
