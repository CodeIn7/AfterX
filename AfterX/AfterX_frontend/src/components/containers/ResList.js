// import React, { useEffect } from 'react';
// import { useSelector, useDispatch } from 'react-redux';
// import PropTypes from 'prop-types';
// import { makeStyles } from '@material-ui/core/styles';
// import Box from '@material-ui/core/Box';
// import Collapse from '@material-ui/core/Collapse';
// import IconButton from '@material-ui/core/IconButton';
// import Table from '@material-ui/core/Table';
// import TableBody from '@material-ui/core/TableBody';
// import TableCell from '@material-ui/core/TableCell';
// import TableContainer from '@material-ui/core/TableContainer';
// import TableHead from '@material-ui/core/TableHead';
// import TableRow from '@material-ui/core/TableRow';
// import Typography from '@material-ui/core/Typography';
// import Paper from '@material-ui/core/Paper';
// import ArrowDownwardIcon from '@material-ui/icons/ArrowDownward';
// import ArrowUpwardIcon from '@material-ui/icons/ArrowUpward';
// import { Button } from 'antd';
// import {
//   listReservations,
//   deleteReservation,
// } from '../../_actions/reservation_actions';

// const useRowStyles = makeStyles({
//   root: {
//     '& > *': {
//       borderBottom: 'unset',
//     },
//   },
// });

// function createData(
//   reservationId,
//   personName,
//   personId,
//   reservationTime,
//   idTable,
//   orders,
//   noPeople
// ) {
//   let timeline = [];
//   /*
//     let drinksString=""
//     drinks.map((d)=>{
//         drinksString=drinksString + d.drink.name+", "
//         drinks=drinks + d.drink.name+", "
//     })
// drinksString = drinksString.substring(0, drinksString.length - 2)
//     */
//   const getDrinks = (order) => {
//     let drinks = '';
//     order.drinks.map((d) => {
//       drinks =
//         `${drinks + d.drink.name}(${d.drink.quantity}L)` + ` x${d.quantity}, `;
//     });
//     drinks = drinks.substring(0, drinks.length - 2);
//     return drinks;
//   };
//   const getPrice = (order) => {
//     let price = 0;
//     order.drinks.map((d) => {
//       price += d.drink.price * d.quantity;
//     });
//     return price;
//   };
//   if (orders != undefined) {
//     timeline = orders.map((b) => ({
//       dinks: getDrinks(b.order),
//       arrivalTime: b.order.deliveryTime,
//       price: getPrice(b.order),
//       footnote: b.order.footnote,
//     }));
//   }

//   return {
//     reservationId,
//     personName,
//     personId,
//     reservationTime,
//     idTable,
//     bundleExists:
//       orders != undefined ? (orders.length != 0 ? 'da' : 'ne') : 'ne',
//     noPeople,
//     timeline,
//   };
// }
// function Row(props) {
//   const { row } = props;
//   const [open, setOpen] = React.useState(false);
//   const classes = useRowStyles();
//   const dispatch = useDispatch();

//   const deleteHandler = (personId) => {
//     console.log('deleteHandler', personId);
//     dispatch(deleteReservation(personId));
//   };
//   return (
//     <>
//       <TableRow className={classes.root}>
//         <TableCell>
//           <IconButton
//             aria-label="expand row"
//             size="small"
//             onClick={() => setOpen(!open)}
//           >
//             {open ? (
//               <ArrowUpwardIcon style={{ color: '#032173' }} />
//             ) : (
//               <ArrowDownwardIcon style={{ color: '#032173' }} />
//             )}
//           </IconButton>
//         </TableCell>
//         <TableCell component="th" scope="row">
//           {row.personName}
//         </TableCell>
//         <TableCell align="right">{row.reservationTime}</TableCell>
//         <TableCell align="right">{row.idTable}</TableCell>
//         <TableCell align="right">{row.bundleExists}</TableCell>
//         <TableCell align="right">{row.noPeople}</TableCell>
//         <TableCell component="th" scope="row">
//           <Button
//             type="danger"
//             shape="round"
//             icon="delete"
//             theme="filled"
//             onClick={() => deleteHandler(row.reservationId)}
//           />
//         </TableCell>
//       </TableRow>
//       <TableRow>
//         <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
//           <Collapse in={open} timeout="auto" unmountOnExit>
//             <Box margin={1}>
//               <Typography variant="h6" gutterBottom component="div">
//                 Vremenska crta posluge
//               </Typography>
//               <Table size="small" aria-label="purchases">
//                 <TableHead>
//                   <TableRow>
//                     <TableCell>Narudžbe</TableCell>
//                     <TableCell>Vrijeme posluge</TableCell>
//                     <TableCell>Cijena</TableCell>
//                     <TableCell>Note</TableCell>
//                   </TableRow>
//                 </TableHead>
//                 <TableBody>
//                   {row.timeline.map((t) => (
//                     <TableRow key={t.dinks} className={classes.root}>
//                       <TableCell component="th" scope="row">
//                         {t.dinks}
//                       </TableCell>
//                       <TableCell>{t.arrivalTime}</TableCell>
//                       <TableCell>{t.price}</TableCell>
//                       <TableCell>{t.footnote}</TableCell>
//                     </TableRow>
//                   ))}
//                 </TableBody>
//               </Table>
//             </Box>
//           </Collapse>
//         </TableCell>
//       </TableRow>
//     </>
//   );
// }
// Row.propTypes = {
//   row: PropTypes.shape({
//     reservationId: PropTypes.string.isRequired,
//     reservationTime: PropTypes.string.isRequired,
//     personId: PropTypes.string.isRequired,
//     noPeople: PropTypes.number.isRequired,
//     bundleExists: PropTypes.string.isRequired,
//     personName: PropTypes.string.isRequired,
//     idTable: PropTypes.number.isRequired,
//     timeline: PropTypes.arrayOf(
//       PropTypes.shape({
//         dinks: PropTypes.string.isRequired,
//         arrivalTime: PropTypes.string.isRequired,
//         price: PropTypes.string.isRequired,
//         footnote: PropTypes.string.isRequired,
//       })
//     ).isRequired,
//   }).isRequired,
// };

// const ResList = () => {
//   const reservationList = useSelector((state) => state.reservations);
//   const user = useSelector((state) => state.user);
//   const savedRes = useSelector((state) => state.savedRes);
//   const { success: successSave } = savedRes;
//   const reservationDelete = useSelector((state) => state.reservationDelete);
//   const { reservations, loading, error } = reservationList;
//   const { success: successDelete } = reservationDelete;
//   let listReservationsComplete = false;

//   const dispatch = useDispatch();
//   useEffect(() => {
//     if (
//       (user.userData !== undefined && !listReservationsComplete) ||
//       successDelete
//     ) {
//       dispatch(listReservations(user.userData.club));
//       listReservationsComplete = true;
//     }
//     return () => {};
//   }, [successDelete, user, successSave]);

//   const rows = reservations.map((r) =>
//     createData(
//       r._id,
//       r.userName,
//       r.user._id,
//       r.reservationTime,
//       r.table.tableNumber,
//       r.orders,
//       r.noPeople
//     )
//   );
//   return (
//     <TableContainer component={Paper}>
//       <Table aria-label="collapsible table">
//         <TableHead style={{ backgroundColor: '#032173', color: 'white' }}>
//           <TableRow>
//             <TableCell />
//             <TableCell style={{ color: 'white' }}>Rezervacije</TableCell>
//             <TableCell style={{ color: 'white' }} align="right">
//               Vrijeme
//             </TableCell>
//             <TableCell style={{ color: 'white' }} align="right">
//               Stol
//             </TableCell>
//             <TableCell style={{ color: 'white' }} align="right">
//               Narudžbe
//             </TableCell>
//             <TableCell style={{ color: 'white' }} align="right">
//               Broj ljudi
//             </TableCell>
//             <TableCell style={{ color: 'white' }}>Akcije </TableCell>
//           </TableRow>
//         </TableHead>
//         {loading ? (
//           <TableBody>
//             <TableRow>
//               <TableCell />
//               <TableCell>Loading...</TableCell>
//               <TableCell align="right">Loading...</TableCell>
//               <TableCell align="right">Loading...</TableCell>
//               <TableCell align="right">Loading...</TableCell>
//               <TableCell align="right">Loading...</TableCell>
//             </TableRow>
//           </TableBody>
//         ) : error ? (
//           <TableBody>
//             <TableRow>
//               <TableCell>{error}</TableCell>
//             </TableRow>
//           </TableBody>
//         ) : (
//           <TableBody>
//             {rows.map((row) => (
//               <Row key={row.reservationId} row={row} />
//             ))}
//           </TableBody>
//         )}
//       </Table>
//     </TableContainer>
//   );
// };
// export default ResList;
