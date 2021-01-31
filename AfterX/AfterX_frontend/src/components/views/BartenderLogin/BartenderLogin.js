import React, { Component } from 'react';
import './BartenderLogin.css';
import Slideshow from '../../utils/Slideshow';
import slide1 from '../slides/slide1.jpg';
import slide2 from '../slides/slide6.jpg';
import slide3 from '../slides/slide3.jfif';
import slide4 from '../slides/slide4.jpg';
import slide5 from '../slides/slide5.jpg';
import LoginPage from '../LoginPage/LoginPage';
import image from '../wb.png';
import { Row, Col } from 'antd';

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter fSize2',
  main: 'flex8 white',
  footer: 'flex1 fCenter',
  floatingLogin: 'floatingLogin',
};

const slides = [slide1, slide2, slide3, slide4, slide5];

class BartenderLogin extends Component {
  render() {
    return (
      <Row justify="center" className={s.container}>
        <Col
          span={24}
          flex="auto"
          className={s.header}
          style={{ height: '15px' }}
        >
          <Row
            justify="space-between"
            align="middle"
            style={{ height: '100%' }}
          >
            <Col span={3} style={{ width: '100%', height: '100%' }}>
              {/* <Button
                className="navButton"
                type="primary"
                ghost
                onClick={() => this.navigateTo('/drinks')}
              >
                Your clubs
              </Button> */}
            </Col>
            <Col span={4} style={{ width: '100%', height: '100%' }}>
              <Row justify="center">
                <img className="logoImage" src={image} alt="Slika" />
              </Row>
            </Col>
            <Col span={3} style={{ width: '100%', height: '100%' }}>
              {/* <Button className="navButton" type="primary" ghost>
                Log out
              </Button> */}
            </Col>
          </Row>
        </Col>
        <Col span={24} className={s.main}>
          <Slideshow slides={slides} />
          <Col span={20} className="reservationForm">
            <LoginPage />
          </Col>
        </Col>
      </Row>
    );
  }
}

export default BartenderLogin;
