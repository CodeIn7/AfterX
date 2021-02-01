export const orderConfig = [
  {
    type: 'text',
    field: 'name',
    label: 'Drink name',
    style: {
      color: 'red',
      margin: '10px',
    },
    validationType: 'string',
    validations: [
      {
        type: 'required',
        params: ['Name is required'],
      },
    ],
  },
  {
    type: 'number',
    field: 'quantity',
    label: 'Quantity',
    style: {
      color: 'green',
      margin: '10px',
    },
    validationType: 'number',
    validations: [
      {
        type: 'min',
        params: [0.03, 'Min quantity is 0.03'],
      },
      {
        type: 'max',
        params: [3, 'Max quantity is 3'],
      },
      {
        type: 'required',
        params: ['Quantity is required'],
      },
    ],
  },
  {
    type: 'text',
    field: 'type',
    label: 'Type',
    style: {
      color: 'red',
      margin: '10px',
    },
    validationType: 'string',
    validations: [
      {
        type: 'required',
        params: ['A type is required'],
      },
    ],
  },
];
