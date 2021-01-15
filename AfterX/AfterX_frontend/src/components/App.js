import React, { Suspense } from 'react';
import { Route, Switch, withRouter } from 'react-router-dom';
import Auth from '../hoc/auth';
import LandingPage from './views/LandingPage/LandingPage.js';
import BartenderLandingPage from './views/BartenderLandingPage/BartenderLandingPage.js';
import BartenderLogin from './views/BartenderLogin/BartenderLogin';
import BartenderRegister from './views/BartenderRegister/BartenderRegister';
import UserLandingPage from './views/UserLandingPage/UserLandingPage';
import CustomChatbot from './chatbot/CustomChatbot';

// null   Anyone Can go inside
// true   only logged in user can go inside
// false  logged in user can't go inside

function App() {
  return (
    <Suspense fallback={<div>Loading...</div>}>
      <div style={{ paddingTop: '0px', minHeight: 'calc(100vh - 80px)' }}>
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
          <Route exact path="/User" component={UserLandingPage} />
          <Route
            exact
            path="/register"
            // component={Auth(BartenderRegister, null)}
            component={BartenderRegister}
          />
        </Switch>
        <CustomChatbot />
      </div>
    </Suspense>
  );
}

export default withRouter(App);
