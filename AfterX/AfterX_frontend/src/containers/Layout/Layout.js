import React from 'react';
import { Row, Col, Button } from 'antd';
import Slideshow from '../../components/utils/Slideshow';
import slide1 from '../../components/views/slides/slide1.jpg';
import slide2 from '../../components/views/slides/slide6.jpg';
import slide3 from '../../components/views/slides/slide3.jfif';
import slide4 from '../../components/views/slides/slide4.jpg';
import slide5 from '../../components/views/slides/slide5.jpg';
import image from '../../components/views/gg1.png';

const slides = [slide1, slide2, slide3, slide4, slide5];

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter',
  main: 'flex8 white',
  footer: 'flex1 fCenter',
};

function Layout(props) {
  return (
    <div>
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
            {props.children}
          </Col>
        </Col>
      </Row>
    </div>
  );
}
export default Layout;
