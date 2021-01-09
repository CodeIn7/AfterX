--
-- PostgreSQL database dump
--

-- Dumped from database version 11.6
-- Dumped by pg_dump version 13.0

-- Started on 2021-01-08 14:28:49

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 5 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: azure_superuser
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO azure_superuser;

--
-- TOC entry 4463 (class 0 OID 0)
-- Dependencies: 5
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: azure_superuser
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

--
-- TOC entry 214 (class 1259 OID 17449)
-- Name: address; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.address (
    id integer NOT NULL,
    cityid integer NOT NULL,
    street character varying NOT NULL,
    number character varying
);


ALTER TABLE public.address OWNER TO afterx2021;

--
-- TOC entry 213 (class 1259 OID 17447)
-- Name: address_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.address_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.address_id_seq OWNER TO afterx2021;

--
-- TOC entry 4464 (class 0 OID 0)
-- Dependencies: 213
-- Name: address_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.address_id_seq OWNED BY public.address.id;


--
-- TOC entry 210 (class 1259 OID 17423)
-- Name: city; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.city (
    id integer NOT NULL,
    countryid integer NOT NULL,
    name character varying NOT NULL,
    zip numeric
);


ALTER TABLE public.city OWNER TO afterx2021;

--
-- TOC entry 209 (class 1259 OID 17421)
-- Name: city_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.city_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.city_id_seq OWNER TO afterx2021;

--
-- TOC entry 4465 (class 0 OID 0)
-- Dependencies: 209
-- Name: city_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.city_id_seq OWNED BY public.city.id;


--
-- TOC entry 208 (class 1259 OID 17410)
-- Name: club; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.club (
    id integer NOT NULL,
    name character varying NOT NULL,
    addressid integer
);


ALTER TABLE public.club OWNER TO afterx2021;

--
-- TOC entry 207 (class 1259 OID 17408)
-- Name: club_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.club_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.club_id_seq OWNER TO afterx2021;

--
-- TOC entry 4466 (class 0 OID 0)
-- Dependencies: 207
-- Name: club_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.club_id_seq OWNED BY public.club.id;


--
-- TOC entry 212 (class 1259 OID 17436)
-- Name: country; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.country (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.country OWNER TO afterx2021;

--
-- TOC entry 211 (class 1259 OID 17434)
-- Name: country_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.country_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.country_id_seq OWNER TO afterx2021;

--
-- TOC entry 4467 (class 0 OID 0)
-- Dependencies: 211
-- Name: country_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.country_id_seq OWNED BY public.country.id;


--
-- TOC entry 217 (class 1259 OID 17471)
-- Name: drink; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.drink (
    id integer NOT NULL,
    quantity numeric NOT NULL,
    name character varying NOT NULL,
    drinktypeid integer NOT NULL
);


ALTER TABLE public.drink OWNER TO afterx2021;

--
-- TOC entry 224 (class 1259 OID 17512)
-- Name: drinkType; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public."drinkType" (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."drinkType" OWNER TO afterx2021;

--
-- TOC entry 223 (class 1259 OID 17510)
-- Name: drinkType_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public."drinkType_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."drinkType_id_seq" OWNER TO afterx2021;

--
-- TOC entry 4468 (class 0 OID 0)
-- Dependencies: 223
-- Name: drinkType_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public."drinkType_id_seq" OWNED BY public."drinkType".id;


--
-- TOC entry 215 (class 1259 OID 17460)
-- Name: drink_club; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.drink_club (
    drinkid integer NOT NULL,
    clubid integer NOT NULL,
    price numeric NOT NULL,
    CONSTRAINT drink_club_price_check CHECK ((price > (0)::numeric))
);


ALTER TABLE public.drink_club OWNER TO afterx2021;

--
-- TOC entry 216 (class 1259 OID 17469)
-- Name: drink_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.drink_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.drink_id_seq OWNER TO afterx2021;

--
-- TOC entry 4469 (class 0 OID 0)
-- Dependencies: 216
-- Name: drink_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.drink_id_seq OWNED BY public.drink.id;


--
-- TOC entry 236 (class 1259 OID 17584)
-- Name: event; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.event (
    id integer NOT NULL,
    clubid integer NOT NULL,
    _date date,
    description character varying,
    price numeric,
    active boolean
);


ALTER TABLE public.event OWNER TO afterx2021;

--
-- TOC entry 235 (class 1259 OID 17582)
-- Name: event_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.event_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.event_id_seq OWNER TO afterx2021;

--
-- TOC entry 4470 (class 0 OID 0)
-- Dependencies: 235
-- Name: event_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.event_id_seq OWNED BY public.event.id;


--
-- TOC entry 228 (class 1259 OID 17535)
-- Name: order; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public."order" (
    id integer NOT NULL,
    tableid integer NOT NULL,
    reservationid integer NOT NULL,
    _note character varying,
    "time" time without time zone NOT NULL,
    active boolean
);


ALTER TABLE public."order" OWNER TO afterx2021;

--
-- TOC entry 229 (class 1259 OID 17546)
-- Name: order_drink; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.order_drink (
    orderid integer NOT NULL,
    drinkid integer NOT NULL,
    nobottles smallint NOT NULL
);


ALTER TABLE public.order_drink OWNER TO afterx2021;

--
-- TOC entry 227 (class 1259 OID 17533)
-- Name: order_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.order_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.order_id_seq OWNER TO afterx2021;

--
-- TOC entry 4471 (class 0 OID 0)
-- Dependencies: 227
-- Name: order_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.order_id_seq OWNED BY public."order".id;


--
-- TOC entry 232 (class 1259 OID 17558)
-- Name: package; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.package (
    id integer NOT NULL,
    name character varying NOT NULL,
    price numeric NOT NULL
);


ALTER TABLE public.package OWNER TO afterx2021;

--
-- TOC entry 230 (class 1259 OID 17551)
-- Name: package_drink; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.package_drink (
    packageid integer NOT NULL,
    drinkid integer NOT NULL,
    nobottles smallint NOT NULL
);


ALTER TABLE public.package_drink OWNER TO afterx2021;

--
-- TOC entry 231 (class 1259 OID 17556)
-- Name: package_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.package_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.package_id_seq OWNER TO afterx2021;

--
-- TOC entry 4472 (class 0 OID 0)
-- Dependencies: 231
-- Name: package_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.package_id_seq OWNED BY public.package.id;


--
-- TOC entry 226 (class 1259 OID 17525)
-- Name: reservation; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.reservation (
    id integer NOT NULL,
    tableid integer NOT NULL,
    userid integer NOT NULL,
    reservationdate date NOT NULL,
    numberofpeople smallint NOT NULL
);


ALTER TABLE public.reservation OWNER TO afterx2021;

--
-- TOC entry 225 (class 1259 OID 17523)
-- Name: reservation_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.reservation_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.reservation_id_seq OWNER TO afterx2021;

--
-- TOC entry 4473 (class 0 OID 0)
-- Dependencies: 225
-- Name: reservation_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.reservation_id_seq OWNED BY public.reservation.id;


--
-- TOC entry 234 (class 1259 OID 17571)
-- Name: review; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.review (
    id integer NOT NULL,
    clubid integer NOT NULL,
    userid integer NOT NULL,
    date date NOT NULL,
    desciption character varying,
    grade smallint
);


ALTER TABLE public.review OWNER TO afterx2021;

--
-- TOC entry 233 (class 1259 OID 17569)
-- Name: review_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.review_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.review_id_seq OWNER TO afterx2021;

--
-- TOC entry 4474 (class 0 OID 0)
-- Dependencies: 233
-- Name: review_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.review_id_seq OWNED BY public.review.id;


--
-- TOC entry 205 (class 1259 OID 17392)
-- Name: role; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.role (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.role OWNER TO afterx2021;

--
-- TOC entry 204 (class 1259 OID 17390)
-- Name: role_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.role_id_seq OWNER TO afterx2021;

--
-- TOC entry 4475 (class 0 OID 0)
-- Dependencies: 204
-- Name: role_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.role_id_seq OWNED BY public.role.id;


--
-- TOC entry 206 (class 1259 OID 17403)
-- Name: role_user; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.role_user (
    userid integer NOT NULL,
    roleid integer NOT NULL
);


ALTER TABLE public.role_user OWNER TO afterx2021;

--
-- TOC entry 220 (class 1259 OID 17486)
-- Name: table; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public."table" (
    id integer NOT NULL,
    number integer NOT NULL,
    tabletypeid integer NOT NULL,
    clubid integer NOT NULL,
    capacity smallint,
    minnobottles smallint NOT NULL,
    CONSTRAINT table_capacity_check CHECK ((capacity >= 0)),
    CONSTRAINT table_minnobottles_check CHECK ((minnobottles >= 0))
);


ALTER TABLE public."table" OWNER TO afterx2021;

--
-- TOC entry 222 (class 1259 OID 17499)
-- Name: tableType; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public."tableType" (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."tableType" OWNER TO afterx2021;

--
-- TOC entry 221 (class 1259 OID 17497)
-- Name: tableType_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public."tableType_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."tableType_id_seq" OWNER TO afterx2021;

--
-- TOC entry 4476 (class 0 OID 0)
-- Dependencies: 221
-- Name: tableType_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public."tableType_id_seq" OWNED BY public."tableType".id;


--
-- TOC entry 218 (class 1259 OID 17482)
-- Name: table_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.table_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.table_id_seq OWNER TO afterx2021;

--
-- TOC entry 4477 (class 0 OID 0)
-- Dependencies: 218
-- Name: table_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.table_id_seq OWNED BY public."table".id;


--
-- TOC entry 219 (class 1259 OID 17484)
-- Name: table_number_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.table_number_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.table_number_seq OWNER TO afterx2021;

--
-- TOC entry 4478 (class 0 OID 0)
-- Dependencies: 219
-- Name: table_number_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.table_number_seq OWNED BY public."table".number;


--
-- TOC entry 201 (class 1259 OID 17365)
-- Name: user; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public."user" (
    id integer NOT NULL,
    email character varying NOT NULL,
    password character varying NOT NULL
);


ALTER TABLE public."user" OWNER TO afterx2021;

--
-- TOC entry 200 (class 1259 OID 17363)
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_id_seq OWNER TO afterx2021;

--
-- TOC entry 4479 (class 0 OID 0)
-- Dependencies: 200
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- TOC entry 203 (class 1259 OID 17378)
-- Name: userattribues; Type: TABLE; Schema: public; Owner: afterx2021
--

CREATE TABLE public.userattribues (
    id integer NOT NULL,
    userid integer NOT NULL,
    firstname character varying NOT NULL,
    lastname character varying NOT NULL,
    gender character(1),
    yearofbirth date,
    telephone character varying,
    CONSTRAINT userattribues_gender_check CHECK (((gender = 'M'::bpchar) OR (gender = 'F'::bpchar)))
);


ALTER TABLE public.userattribues OWNER TO afterx2021;

--
-- TOC entry 202 (class 1259 OID 17376)
-- Name: userattribues_id_seq; Type: SEQUENCE; Schema: public; Owner: afterx2021
--

CREATE SEQUENCE public.userattribues_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.userattribues_id_seq OWNER TO afterx2021;

--
-- TOC entry 4480 (class 0 OID 0)
-- Dependencies: 202
-- Name: userattribues_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: afterx2021
--

ALTER SEQUENCE public.userattribues_id_seq OWNED BY public.userattribues.id;


--
-- TOC entry 4229 (class 2604 OID 17452)
-- Name: address id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.address ALTER COLUMN id SET DEFAULT nextval('public.address_id_seq'::regclass);


--
-- TOC entry 4227 (class 2604 OID 17426)
-- Name: city id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.city ALTER COLUMN id SET DEFAULT nextval('public.city_id_seq'::regclass);


--
-- TOC entry 4226 (class 2604 OID 17413)
-- Name: club id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.club ALTER COLUMN id SET DEFAULT nextval('public.club_id_seq'::regclass);


--
-- TOC entry 4228 (class 2604 OID 17439)
-- Name: country id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.country ALTER COLUMN id SET DEFAULT nextval('public.country_id_seq'::regclass);


--
-- TOC entry 4231 (class 2604 OID 17474)
-- Name: drink id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.drink ALTER COLUMN id SET DEFAULT nextval('public.drink_id_seq'::regclass);


--
-- TOC entry 4237 (class 2604 OID 17515)
-- Name: drinkType id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."drinkType" ALTER COLUMN id SET DEFAULT nextval('public."drinkType_id_seq"'::regclass);


--
-- TOC entry 4242 (class 2604 OID 17587)
-- Name: event id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.event ALTER COLUMN id SET DEFAULT nextval('public.event_id_seq'::regclass);


--
-- TOC entry 4239 (class 2604 OID 17538)
-- Name: order id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."order" ALTER COLUMN id SET DEFAULT nextval('public.order_id_seq'::regclass);


--
-- TOC entry 4240 (class 2604 OID 17561)
-- Name: package id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.package ALTER COLUMN id SET DEFAULT nextval('public.package_id_seq'::regclass);


--
-- TOC entry 4238 (class 2604 OID 17528)
-- Name: reservation id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.reservation ALTER COLUMN id SET DEFAULT nextval('public.reservation_id_seq'::regclass);


--
-- TOC entry 4241 (class 2604 OID 17574)
-- Name: review id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.review ALTER COLUMN id SET DEFAULT nextval('public.review_id_seq'::regclass);


--
-- TOC entry 4225 (class 2604 OID 17395)
-- Name: role id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.role ALTER COLUMN id SET DEFAULT nextval('public.role_id_seq'::regclass);


--
-- TOC entry 4232 (class 2604 OID 17489)
-- Name: table id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."table" ALTER COLUMN id SET DEFAULT nextval('public.table_id_seq'::regclass);


--
-- TOC entry 4233 (class 2604 OID 17490)
-- Name: table number; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."table" ALTER COLUMN number SET DEFAULT nextval('public.table_number_seq'::regclass);


--
-- TOC entry 4236 (class 2604 OID 17502)
-- Name: tableType id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."tableType" ALTER COLUMN id SET DEFAULT nextval('public."tableType_id_seq"'::regclass);


--
-- TOC entry 4222 (class 2604 OID 17368)
-- Name: user id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- TOC entry 4223 (class 2604 OID 17381)
-- Name: userattribues id; Type: DEFAULT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.userattribues ALTER COLUMN id SET DEFAULT nextval('public.userattribues_id_seq'::regclass);


--
-- TOC entry 4270 (class 2606 OID 17459)
-- Name: address address_cityid_street_number_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.address
    ADD CONSTRAINT address_cityid_street_number_key UNIQUE (cityid, street, number);


--
-- TOC entry 4272 (class 2606 OID 17457)
-- Name: address address_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.address
    ADD CONSTRAINT address_pkey PRIMARY KEY (id);


--
-- TOC entry 4262 (class 2606 OID 17433)
-- Name: city city_countryid_name_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.city
    ADD CONSTRAINT city_countryid_name_key UNIQUE (countryid, name);


--
-- TOC entry 4264 (class 2606 OID 17431)
-- Name: city city_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.city
    ADD CONSTRAINT city_pkey PRIMARY KEY (id);


--
-- TOC entry 4258 (class 2606 OID 17420)
-- Name: club club_name_addressid_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.club
    ADD CONSTRAINT club_name_addressid_key UNIQUE (name, addressid);


--
-- TOC entry 4260 (class 2606 OID 17418)
-- Name: club club_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.club
    ADD CONSTRAINT club_pkey PRIMARY KEY (id);


--
-- TOC entry 4266 (class 2606 OID 17446)
-- Name: country country_name_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.country
    ADD CONSTRAINT country_name_key UNIQUE (name);


--
-- TOC entry 4268 (class 2606 OID 17444)
-- Name: country country_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.country
    ADD CONSTRAINT country_pkey PRIMARY KEY (id);


--
-- TOC entry 4288 (class 2606 OID 17522)
-- Name: drinkType drinkType_name_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."drinkType"
    ADD CONSTRAINT "drinkType_name_key" UNIQUE (name);


--
-- TOC entry 4290 (class 2606 OID 17520)
-- Name: drinkType drinkType_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."drinkType"
    ADD CONSTRAINT "drinkType_pkey" PRIMARY KEY (id);


--
-- TOC entry 4274 (class 2606 OID 17468)
-- Name: drink_club drink_club_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.drink_club
    ADD CONSTRAINT drink_club_pkey PRIMARY KEY (drinkid, clubid);


--
-- TOC entry 4276 (class 2606 OID 17479)
-- Name: drink drink_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.drink
    ADD CONSTRAINT drink_pkey PRIMARY KEY (id);


--
-- TOC entry 4278 (class 2606 OID 17481)
-- Name: drink drink_quantity_name_drinktypeid_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.drink
    ADD CONSTRAINT drink_quantity_name_drinktypeid_key UNIQUE (quantity, name, drinktypeid);


--
-- TOC entry 4312 (class 2606 OID 17592)
-- Name: event event_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.event
    ADD CONSTRAINT event_pkey PRIMARY KEY (id);


--
-- TOC entry 4300 (class 2606 OID 17550)
-- Name: order_drink order_drink_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.order_drink
    ADD CONSTRAINT order_drink_pkey PRIMARY KEY (orderid, drinkid);


--
-- TOC entry 4296 (class 2606 OID 17543)
-- Name: order order_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."order"
    ADD CONSTRAINT order_pkey PRIMARY KEY (id);


--
-- TOC entry 4298 (class 2606 OID 17545)
-- Name: order order_tableid_reservationid_time_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."order"
    ADD CONSTRAINT order_tableid_reservationid_time_key UNIQUE (tableid, reservationid, "time");


--
-- TOC entry 4302 (class 2606 OID 17555)
-- Name: package_drink package_drink_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.package_drink
    ADD CONSTRAINT package_drink_pkey PRIMARY KEY (packageid, drinkid);


--
-- TOC entry 4304 (class 2606 OID 17568)
-- Name: package package_name_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.package
    ADD CONSTRAINT package_name_key UNIQUE (name);


--
-- TOC entry 4306 (class 2606 OID 17566)
-- Name: package package_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.package
    ADD CONSTRAINT package_pkey PRIMARY KEY (id);


--
-- TOC entry 4292 (class 2606 OID 17530)
-- Name: reservation reservation_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.reservation
    ADD CONSTRAINT reservation_pkey PRIMARY KEY (id);


--
-- TOC entry 4294 (class 2606 OID 17532)
-- Name: reservation reservation_tableid_userid_reservationdate_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.reservation
    ADD CONSTRAINT reservation_tableid_userid_reservationdate_key UNIQUE (tableid, userid, reservationdate);


--
-- TOC entry 4308 (class 2606 OID 17581)
-- Name: review review_clubid_userid_date_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.review
    ADD CONSTRAINT review_clubid_userid_date_key UNIQUE (clubid, userid, date);


--
-- TOC entry 4310 (class 2606 OID 17579)
-- Name: review review_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.review
    ADD CONSTRAINT review_pkey PRIMARY KEY (id);


--
-- TOC entry 4252 (class 2606 OID 17402)
-- Name: role role_name_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_name_key UNIQUE (name);


--
-- TOC entry 4254 (class 2606 OID 17400)
-- Name: role role_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_pkey PRIMARY KEY (id);


--
-- TOC entry 4256 (class 2606 OID 17407)
-- Name: role_user role_user_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_pkey PRIMARY KEY (userid, roleid);


--
-- TOC entry 4284 (class 2606 OID 17509)
-- Name: tableType tableType_name_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."tableType"
    ADD CONSTRAINT "tableType_name_key" UNIQUE (name);


--
-- TOC entry 4286 (class 2606 OID 17507)
-- Name: tableType tableType_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."tableType"
    ADD CONSTRAINT "tableType_pkey" PRIMARY KEY (id);


--
-- TOC entry 4280 (class 2606 OID 17496)
-- Name: table table_number_clubid_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."table"
    ADD CONSTRAINT table_number_clubid_key UNIQUE (number, clubid);


--
-- TOC entry 4282 (class 2606 OID 17494)
-- Name: table table_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."table"
    ADD CONSTRAINT table_pkey PRIMARY KEY (id);


--
-- TOC entry 4244 (class 2606 OID 17375)
-- Name: user user_email_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_email_key UNIQUE (email);


--
-- TOC entry 4246 (class 2606 OID 17373)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- TOC entry 4248 (class 2606 OID 17387)
-- Name: userattribues userattribues_pkey; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.userattribues
    ADD CONSTRAINT userattribues_pkey PRIMARY KEY (id);


--
-- TOC entry 4250 (class 2606 OID 17389)
-- Name: userattribues userattribues_userid_key; Type: CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.userattribues
    ADD CONSTRAINT userattribues_userid_key UNIQUE (userid);


--
-- TOC entry 4318 (class 2606 OID 17613)
-- Name: address address_cityid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.address
    ADD CONSTRAINT address_cityid_fkey FOREIGN KEY (cityid) REFERENCES public.city(id) ON DELETE CASCADE;


--
-- TOC entry 4317 (class 2606 OID 17618)
-- Name: city city_countryid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.city
    ADD CONSTRAINT city_countryid_fkey FOREIGN KEY (countryid) REFERENCES public.country(id) ON DELETE CASCADE;


--
-- TOC entry 4316 (class 2606 OID 17608)
-- Name: club club_addressid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.club
    ADD CONSTRAINT club_addressid_fkey FOREIGN KEY (addressid) REFERENCES public.address(id) ON DELETE SET NULL;


--
-- TOC entry 4320 (class 2606 OID 17663)
-- Name: drink_club drink_club_clubid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.drink_club
    ADD CONSTRAINT drink_club_clubid_fkey FOREIGN KEY (clubid) REFERENCES public.club(id) ON DELETE CASCADE;


--
-- TOC entry 4319 (class 2606 OID 17658)
-- Name: drink_club drink_club_drinkid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.drink_club
    ADD CONSTRAINT drink_club_drinkid_fkey FOREIGN KEY (drinkid) REFERENCES public.drink(id) ON DELETE CASCADE;


--
-- TOC entry 4321 (class 2606 OID 17683)
-- Name: drink drink_drinktypeid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.drink
    ADD CONSTRAINT drink_drinktypeid_fkey FOREIGN KEY (drinktypeid) REFERENCES public."drinkType"(id);


--
-- TOC entry 4334 (class 2606 OID 17623)
-- Name: event event_clubid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.event
    ADD CONSTRAINT event_clubid_fkey FOREIGN KEY (clubid) REFERENCES public.club(id) ON DELETE CASCADE;


--
-- TOC entry 4329 (class 2606 OID 17653)
-- Name: order_drink order_drink_drinkid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.order_drink
    ADD CONSTRAINT order_drink_drinkid_fkey FOREIGN KEY (drinkid) REFERENCES public.drink(id) ON DELETE CASCADE;


--
-- TOC entry 4328 (class 2606 OID 17648)
-- Name: order_drink order_drink_orderid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.order_drink
    ADD CONSTRAINT order_drink_orderid_fkey FOREIGN KEY (orderid) REFERENCES public."order"(id) ON DELETE CASCADE;


--
-- TOC entry 4326 (class 2606 OID 17643)
-- Name: order order_reservationid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."order"
    ADD CONSTRAINT order_reservationid_fkey FOREIGN KEY (reservationid) REFERENCES public.reservation(id) ON DELETE CASCADE;


--
-- TOC entry 4327 (class 2606 OID 17698)
-- Name: order order_tableid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."order"
    ADD CONSTRAINT order_tableid_fkey FOREIGN KEY (tableid) REFERENCES public."table"(id) ON DELETE CASCADE;


--
-- TOC entry 4331 (class 2606 OID 17693)
-- Name: package_drink package_drink_drinkid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.package_drink
    ADD CONSTRAINT package_drink_drinkid_fkey FOREIGN KEY (drinkid) REFERENCES public.drink(id) ON DELETE CASCADE;


--
-- TOC entry 4330 (class 2606 OID 17688)
-- Name: package_drink package_drink_packageid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.package_drink
    ADD CONSTRAINT package_drink_packageid_fkey FOREIGN KEY (packageid) REFERENCES public.package(id) ON DELETE CASCADE;


--
-- TOC entry 4324 (class 2606 OID 17633)
-- Name: reservation reservation_tableid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.reservation
    ADD CONSTRAINT reservation_tableid_fkey FOREIGN KEY (tableid) REFERENCES public."table"(id);


--
-- TOC entry 4325 (class 2606 OID 17638)
-- Name: reservation reservation_userid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.reservation
    ADD CONSTRAINT reservation_userid_fkey FOREIGN KEY (userid) REFERENCES public."user"(id) ON DELETE CASCADE;


--
-- TOC entry 4332 (class 2606 OID 17668)
-- Name: review review_clubid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.review
    ADD CONSTRAINT review_clubid_fkey FOREIGN KEY (clubid) REFERENCES public.club(id) ON DELETE CASCADE;


--
-- TOC entry 4333 (class 2606 OID 17673)
-- Name: review review_userid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.review
    ADD CONSTRAINT review_userid_fkey FOREIGN KEY (userid) REFERENCES public."user"(id) ON DELETE CASCADE;


--
-- TOC entry 4314 (class 2606 OID 17598)
-- Name: role_user role_user_roleid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_roleid_fkey FOREIGN KEY (roleid) REFERENCES public.role(id) ON DELETE CASCADE;


--
-- TOC entry 4315 (class 2606 OID 17603)
-- Name: role_user role_user_userid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_userid_fkey FOREIGN KEY (userid) REFERENCES public.userattribues(userid) ON DELETE CASCADE;


--
-- TOC entry 4322 (class 2606 OID 17628)
-- Name: table table_clubid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."table"
    ADD CONSTRAINT table_clubid_fkey FOREIGN KEY (clubid) REFERENCES public.club(id) ON DELETE CASCADE;


--
-- TOC entry 4323 (class 2606 OID 17678)
-- Name: table table_tabletypeid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public."table"
    ADD CONSTRAINT table_tabletypeid_fkey FOREIGN KEY (tabletypeid) REFERENCES public."tableType"(id);


--
-- TOC entry 4313 (class 2606 OID 17593)
-- Name: userattribues userattribues_userid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: afterx2021
--

ALTER TABLE ONLY public.userattribues
    ADD CONSTRAINT userattribues_userid_fkey FOREIGN KEY (userid) REFERENCES public."user"(id) ON DELETE CASCADE;


-- Completed on 2021-01-08 14:29:15

--
-- PostgreSQL database dump complete
--

