import React from 'react';
import styles from './BartenderLanding.module.css';
import ResList from '../../containers/ResList';
import NavBar from '../NavBar/NavBar';

function BartenderLandingPage() {
  return (
    <div className={styles.container}>
      <NavBar />
      <ResList />
    </div>
  );
}

export default BartenderLandingPage;
