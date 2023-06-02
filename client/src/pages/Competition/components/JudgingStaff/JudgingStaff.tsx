import React, { useState } from 'react';
import PersonRemoveIcon from '@mui/icons-material/PersonRemove';
import { TableColumns } from '../../../../types/DataTableTypes';
import { DataTable } from '../../../../components/DataTable';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../../../components/SelectForFilter/SelectForFilter';
import './JudgingStaff.scss';
import { RegisterJudge } from '../../../../components/RegisterJudge';

type Judge = (typeof test)[0];
type ColumnsType = Judge & { controls: string };

const JudgingStaff = () => {
  const [judges, setJudges] = useState(test);
  const [open, setOpen] = useState(false);

  const handleClose = () => setOpen(false);

  const columns: TableColumns<Judge, ColumnsType>[] = [
    {
      name: 'photo',
      label: 'Фото',
    },
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'sex',
      label: 'Стать',
    },
    {
      name: 'birthday',
      label: 'Дата народження',
      sortable: true,
    },
    {
      name: 'club',
      label: 'Клуб',
    },
    {
      name: 'belt',
      label: 'Статус',
    },
    {
      name: 'judgeCategory',
      label: 'Суддівська категорія',
    },
    {
      name: 'membershipCardNum',
      label: 'Номер членського квитка',
    },
    {
      name: 'controls',
      renderItem: () => <PersonRemoveIcon />,
    },
  ];
  return (
    <div className='wrapper'>
      <div className='judges-menu'>
        <TextField label='Пошук'></TextField>
        <SelectForFilter label='Клуб' items={clubsTest} />
        <Button
          variant='contained'
          color='inherit'
          onClick={() => setOpen(true)}
          className='register-button'
        >
          Зареєструвати
        </Button>
      </div>

      <DataTable tableData={test} tableColumns={columns} />
      <RegisterJudge open={open} setClose={handleClose} />
    </div>
  );
};

export { JudgingStaff };

const test = [
  {
    id: 1,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 2,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 3,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 4,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 5,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 6,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 7,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 8,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 9,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 10,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
];
const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];
