const reservations = [
  {
    personName: 'Bruno Jeric',
    personId: 34,
    idTable: 50,
    noPeople: 8,
    reservationTime: '20:50',
    bundle: [
      {
        name: 'Blackout',
        arrival: '21:15',
      },
      {
        name: 'Hangover Bomb',
        arrival: '22:00',
      },
    ],
  },
  {
    personName: 'Ivo Ivic',
    personId: 14,
    idTable: 50,
    noPeople: 8,
    reservationTime: '20:50',
    bundle: [
      {
        name: 'Hangover Bomb',
        arrival: '22:00',
      },
    ],
  },
];
export function req() {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(reservations);
    }, 2000);
  });
}
export function deleteRes(personId) {
  return new Promise((resolve) => {
    const obj = reservations.find((x) => x.personId === personId);
    const index = reservations.indexOf(obj);
    if (index > -1) {
      reservations.splice(index, 1);
    }
    setTimeout(() => {
      resolve(obj);
    }, 2000);
  });
}
