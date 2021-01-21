export const clubConfig = [
  {
    type: 'text',
    field: 'clubName',
    placeholder: 'Enter club name',
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
    placeholder: 'Enter city name',
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
    placeholder: 'Enter street',
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
    placeholder: 'Enter street number',
    validationType: 'string',
    validations: [
      {
        type: 'required',
        params: ['Street Number is required'],
      },
    ],
  },
];
