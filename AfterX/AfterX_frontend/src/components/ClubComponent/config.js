export const clubConfig = [
  {
    type: 'text',
    field: 'clubName',
    label: 'Club Name',
    validationType: 'string',
    validations: [
      {
        type: 'required',
        params: ['Club name is required'],
      },
    ],
  },
  {
    type: 'text',
    field: 'city',
    label: 'City',
    validationType: 'string',
    validations: [
      {
        type: 'required',
        params: ['City is required'],
      },
    ],
  },
  {
    type: 'text',
    field: 'street',
    label: 'Street',
    validationType: 'string',
    validations: [
      {
        type: 'required',
        params: ['Street is required'],
      },
    ],
  },
  {
    type: 'text',
    field: 'streetNumber',
    label: 'Street Number',
    validationType: 'string',
    validations: [
      {
        type: 'required',
        params: ['Street Number is required'],
      },
    ],
  },
];
