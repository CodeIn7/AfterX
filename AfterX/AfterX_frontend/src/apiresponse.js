export default [
  {
    type: 'text',
    field: 'name',
    label: "User's name",
    style: {
      color: 'green',
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
    field: 'age',
    label: "User's age",
    style: {
      color: 'green',
      margin: '10px',
    },
    validationType: 'number',
    validations: [
      {
        type: 'min',
        params: [18, 'Min age is 18'],
      },
      {
        type: 'max',
        params: [60, 'Max age is 50'],
      },
    ],
  },
  {
    type: 'text',
    field: 'email',
    label: "User's Email",
    style: {
      color: 'green',
      margin: '10px',
    },
    validationType: 'string',
    validations: [
      {
        type: 'email',
        params: ['A valid email is required'],
      },
    ],
  },
];
