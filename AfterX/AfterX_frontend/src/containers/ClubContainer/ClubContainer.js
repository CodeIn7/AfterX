import React, { Component } from 'react';
import PropTypes from 'prop-types';
import ClubComponent from '../../components/ClubComponent/ClubComponent';
import Slideshow from '../../components/utils/Slideshow';
import slide1 from '../../components/views/slides/slide1.jpg';
import slide2 from '../../components/views/slides/slide6.jpg';
import slide3 from '../../components/views/slides/slide3.jfif';
import slide4 from '../../components/views/slides/slide4.jpg';
import slide5 from '../../components/views/slides/slide5.jpg';
import image from '../../components/views/wb.png';
import { Row, Col, Button, Layout } from 'antd';
import { Height } from '@material-ui/icons';

const slides = [slide1, slide2, slide3, slide4, slide5];

const { Header, Footer, Sider, Content } = Layout;

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter fSize2',
  main: 'flex8 white',
};

export class ClubContainer extends Component {
  //   static propTypes = {};

  render() {
    return (
      <Row justify="center" className={s.container}>
        <Col span={24} className={s.header}>
          <Row justify="space-between">
            <Col span={8}>
              <Button
                style={{ width: '60px', height: 'auto' }}
                type="primary"
                ghost
              >
                primary
              </Button>
            </Col>
            <Col span={8}>
              <img className="logoImage" src={image} alt="Slika" />
            </Col>
            <Col span={8}></Col>
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
