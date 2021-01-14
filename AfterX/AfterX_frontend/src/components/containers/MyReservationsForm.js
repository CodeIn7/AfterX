import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/lab/Autocomplete';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import CircularProgress from '@material-ui/core/CircularProgress';
import DateFnsUtils from '@date-io/date-fns';
import {
  MuiPickersUtilsProvider,
  KeyboardTimePicker,
  KeyboardDatePicker,
} from '@material-ui/pickers';
import {
  listClubs,
  listClubFreeTables,
  submitNewReservation,
} from '../../_actions/clubs_actions';
import styles from './MyReservationsForm.module.css';

const MyReservationsForm = () => {
  const [selectedDate, setSelectedDate] = React.useState(new Date());
  const [table, setTable] = React.useState(null);
  const [club, setClub] = React.useState(null);
  const [open, setOpen] = React.useState(false);
  const [options, setOptions] = React.useState([]);
  const [open2, setOpen2] = React.useState(false);
  const [options2, setOptions2] = React.useState([]);
  const clubsList = useSelector((state) => state.clubs);
  const tablesList = useSelector((state) => state.tables);
  const { tables, loading: tablesLoading, error: tableError } = tablesList;
  const { clubs, loading: clubsLoading, error } = clubsList;
  let noPeople = 0;
  // var table = {}
  const dispatch = useDispatch();

  const handleDateChange = (date) => {
    setSelectedDate(date);
    console.log(date);
  };
  const handleClubChange = (event, values) => {
    setClub(values);
    dispatch(listClubFreeTables(values._id));
  };
  const numberOfPeopleHandler = (event, values) => {
    noPeople = event.target.value;
  };
  const handleSubmit = () => {
    const data = {
      userName: 'User', // OVDE PROMINIT AKO BUDE VRIMENA
      reservationDate: selectedDate.toISOString().substring(0, 10),
      reservationTime: selectedDate.toISOString().substring(11, 16),
      userId: '5ed8fed995473f2cac3418a2', // I OVO
      tableId: table._id,
      noPeople,
      orders: [],
      clubId: club._id,
    };
    dispatch(submitNewReservation(data));
  };
  const handleTableChange = (event, values) => {
    setTable(values);

    // setTable(values)
  };

  useEffect(() => {
    dispatch(listClubs());

    return () => {};
  }, []);

  return (
    <div className={styles.container}>
      <div className={styles.header}>
        <h1>Rezerviraj svoje mjesto</h1>
      </div>
      <div className={styles.Autocomplete}>
        <Autocomplete
          className={styles.AutocompleteInput}
          id="clubPicker"
          open={open}
          onOpen={() => {
            setOpen(true);
            setOptions(clubs);
          }}
          onClose={() => {
            setOpen(false);
          }}
          getOptionSelected={(option, value) => option.name === value.name}
          getOptionLabel={(option) => option.name}
          options={options}
          loading={clubsLoading}
          onChange={handleClubChange}
          renderInput={(params) => (
            <TextField
              // eslint-disable-next-line react/jsx-props-no-spreading
              {...params}
              label="Odaberi klub"
              variant="outlined"
              InputProps={{
                ...params.InputProps,
                endAdornment: (
                  <>
                    {clubsLoading ? (
                      <CircularProgress color="inherit" size={20} />
                    ) : null}
                    {params.InputProps.endAdornment}
                  </>
                ),
              }}
            />
          )}
        />
      </div>
      <div className={styles.DateTime}>
        <MuiPickersUtilsProvider
          className={styles.pickerGroup}
          utils={DateFnsUtils}
        >
          <Grid container justify="space-around">
            <KeyboardDatePicker
              disableToolbar
              variant="inline"
              format="MM/dd/yyyy"
              margin="normal"
              id="date-picker-inline"
              label="Date picker inline"
              value={selectedDate}
              onChange={handleDateChange}
              KeyboardButtonProps={{
                'aria-label': 'change date',
              }}
            />
            <KeyboardTimePicker
              margin="normal"
              id="time-picker"
              ampm={false}
              label="Time picker"
              value={selectedDate}
              onChange={handleDateChange}
              KeyboardButtonProps={{
                'aria-label': 'change time',
              }}
            />
          </Grid>
        </MuiPickersUtilsProvider>
      </div>
      <div className={styles.thirdRow}>
        <div className={styles.tableSelect}>
          <Autocomplete
            className={styles.AutocompleteInputTables}
            id="tablePicker"
            open={open2}
            onOpen={() => {
              setOpen2(true);
              console.log('on open', tables);
              setOptions2(tables);
            }}
            onClose={() => {
              setOpen2(false);
            }}
            getOptionSelected={(option, value) =>
              option.tableNumber === value.tableNumber
            }
            getOptionLabel={(option) =>
              `Stol br.${option.tableNumber} ${option.typeOfTable}`
            }
            options={options2}
            loading={tablesLoading}
            onChange={handleTableChange}
            renderInput={(params) => (
              <TextField
                // eslint-disable-next-line react/jsx-props-no-spreading
                {...params}
                label="Select Table"
                variant="outlined"
                InputProps={{
                  ...params.InputProps,
                  endAdornment: (
                    <>
                      {clubsLoading ? (
                        <CircularProgress color="inherit" size={20} />
                      ) : null}
                      {params.InputProps.endAdornment}
                    </>
                  ),
                }}
              />
            )}
          />
        </div>
        <div className={styles.peopleNumber}>
          <TextField
            id="outlined-basic"
            label="Broj ljudi"
            placeholder={
              table == null
                ? 'najprije odaberite stol'
                : `max: ${table.noSeats}`
            }
            variant="outlined"
            onChange={numberOfPeopleHandler}
          />
        </div>
      </div>
      <div className={styles.subimt}>
        <Button variant="contained" color="primary" onClick={handleSubmit}>
          Submit
        </Button>
      </div>
    </div>
  );
};
export default MyReservationsForm;
