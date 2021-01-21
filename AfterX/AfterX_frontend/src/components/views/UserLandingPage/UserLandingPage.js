import React from 'react';
import './UserLandingPage.css';
import Slideshow from '../../utils/Slideshow';
import slide1 from '../slides/slide1.jpg';
import slide2 from '../slides/slide6.jpg';
import slide3 from '../slides/slide3.jfif';
import slide4 from '../slides/slide4.jpg';
import slide5 from '../slides/slide5.jpg';
import image from '../wb.png';
import { Row, Col, Menu } from 'antd';

import MyReservationsForm from '../../containers/MyReservationsForm';

const slides = [slide1, slide2, slide3, slide4, slide5];

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter fSize2',
  main: 'flex8 white',
  footer: 'flex1 fCenter',
};

function UserLandingPage() {
  return (
    <Row justify="center" className={s.container}>
      <Col span={24} className={s.header}>
        <img className="logoImage" src={image} alt="Slika" />
      </Col>
      <Col span={24} className={s.main}>
        <Slideshow slides={slides} />
        <Col span={20} className="reservationForm">
          <MyReservationsForm></MyReservationsForm>
        </Col>
      </Col>
    </Row>
  );
}

export default UserLandingPage;
