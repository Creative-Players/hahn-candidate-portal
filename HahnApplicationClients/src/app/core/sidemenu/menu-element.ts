export const menus = [
  {
    name: 'Dashboard',
    icon: 'dashboard',
    link: false,
    open: false,
    sub: [
     {
        name: 'New Candidate.',
        icon: 'person',
        link: '/auth/candidate/candidate-list',
        open: false,
      },
      {
        name: 'Configurations',
        icon: 'settings',
        link: false,
        open: false,
        sub: [
          {
             name: 'New Candidate Type',
             icon: 'category',
             link: '/auth/global/type-list',
             open: false,
          },
        ]
      
      },
      
    ],
  },
  
];
