import React from 'react';
import './UserLandingPage.css';
import { Row, Col, Button } from 'antd';
import Slideshow from '../../utils/Slideshow';
import slide1 from '../slides/slide1.jpg';
import slide2 from '../slides/slide6.jpg';
import slide3 from '../slides/slide3.jfif';
import slide4 from '../slides/slide4.jpg';
import slide5 from '../slides/slide5.jpg';
import image from '../gg1.png';

import MyReservationsForm from '../../containers/MyReservationsForm';

const slides = [slide1, slide2, slide3, slide4, slide5];

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter',
  main: 'flex8 white',
  footer: 'flex1 fCenter',
};

function UserLandingPage(props) {
  return (
    <Row justify="center" className={s.container}>
      <Col
        span={24}
        flex="auto"
        className={s.header}
        style={{ height: '15px' }}
      >
        <Row justify="space-between" align="middle" style={{ height: '100%' }}>
          <Col
            span={4}
            style={{
              width: '100%',
              height: '100%',
              whiteSpace: 'normal',
            }}
          >
            <Button
              className="navButton"
              type="primary"
              ghost
              onClick={() => props.history.push('/reservations')}
            >
              Your reservations
            </Button>
          </Col>
          <Col span={4} style={{ width: '100%', height: '100%' }}>
            <Row justify="center">
              <img className="logoImage" src={image} alt="Slika" />
            </Row>
          </Col>
          <Col span={4} style={{ width: '100%', height: '100%' }}>
            <Button className="navButton" type="primary" ghost>
              Log out
            </Button>
          </Col>
        </Row>
      </Col>
      <Col span={24} className={s.main}>
        <Slideshow slides={slides} />
        <Col span={20} className="reservationForm">
          <MyReservationsForm history={props.history} />
        </Col>
      </Col>
    </Row>
  );
}

export default UserLandingPage;
