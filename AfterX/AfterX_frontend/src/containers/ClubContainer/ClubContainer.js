import React, { Component } from 'react';
import ClubComponent from '../../components/ClubComponent/ClubComponent';
import Slideshow from '../../components/utils/Slideshow';
import slide1 from '../../components/views/slides/slide1.jpg';
import slide2 from '../../components/views/slides/slide6.jpg';
import slide3 from '../../components/views/slides/slide3.jfif';
import slide4 from '../../components/views/slides/slide4.jpg';
import slide5 from '../../components/views/slides/slide5.jpg';
import image from '../../components/views/gg1.png';
import { Row, Col, Button, Layout } from 'antd';
import './ClubContainer.css';
const slides = [slide1, slide2, slide3, slide4, slide5];

const { Header, Footer, Sider, Content } = Layout;

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter',
  main: 'flex8 white',
};

export class ClubContainer extends Component {
  //   static propTypes = {};
  navigateTo = (URL) => {
    this.props.history.push(URL);
  };
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
              <Button
                className="navButton"
                type="primary"
                ghost
                onClick={() => this.navigateTo('/drinks')}
              >
                Your clubs
              </Button>
            </Col>
            <Col span={4} style={{ width: '100%', height: '100%' }}>
              <Row justify="center">
                <img className="logoImage" src={image} alt="Slika" />
              </Row>
            </Col>
            <Col span={3} style={{ width: '100%', height: '100%' }}>
              <Button className="navButton" type="primary" ghost>
                Log out
              </Button>
            </Col>
          </Row>
        </Col>
        <Col span={24} className={s.main}>
          <Slideshow slides={slides} />
          <Col span={20} className="reservationForm">
            <ClubComponent />
          </Col>
        </Col>
      </Row>
    );
  }
}

export default ClubContainer;
