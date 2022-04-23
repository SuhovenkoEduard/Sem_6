import React, { useEffect, useState } from 'react'
import { Button } from 'react-bootstrap'
import { CourierGroupedReports } from '../../../../constants/types'
import { useFetch } from '../../../../hooks/useFetch'
import { ErrorWrapper } from '../../../../common/ErrorWrapper'
import { createEditCourierSalaryRequest, createGetGroupedReportsRequest } from '../../../../api/api'
import { GroupedReportsVisualizer } from './GroupedReportsVisualizer'

export const ManagerMenu = () => {
  const {
    error, clearError, loading, request,
  } = useFetch()

  const [groupedReports, setGroupedReports] = useState<CourierGroupedReports[]>([])
  const [isFullShown, setIsFullShown] = useState<boolean>(false)

  const getGroupedReportsAsync = async () => {
    setIsFullShown(false)
    clearError()
    try {
      // eslint-disable-next-line max-len
      const groupedReports: CourierGroupedReports[] = await request(createGetGroupedReportsRequest())
      setGroupedReports(groupedReports)
    } catch (e: any) {
      console.log(e.message)
    }
  }

  const editCourierSalaryAsync = async (courierId: number, salary: number) => {
    setIsFullShown(false)
    clearError()
    try {
      await request(createEditCourierSalaryRequest(courierId, salary))
    } catch (e: any) {
      console.log(e.message)
    }
  }

  const editCourierSalary = (courierId: number, salary: number) => (
    editCourierSalaryAsync(courierId, salary).then(() => getGroupedReportsAsync())
  )

  useEffect(() => { getGroupedReportsAsync() }, [])

  const onRefresh = () => {
    clearError()
    getGroupedReportsAsync()
  }

  return (
    <ErrorWrapper
      error={error}
      loading={loading}
      onRefresh={onRefresh}
    >
      <Button
        className="m-2"
        variant="outline-info"
        onClick={getGroupedReportsAsync}
      >
        Refresh grouped reports.
      </Button>
      {isFullShown ? (
        <Button
          className="m-2"
          variant="primary"
          onClick={() => setIsFullShown(false)}
        >
          Collapse.
        </Button>
      ) : (
        <Button
          className="m-2"
          variant="outline-info"
          onClick={() => setIsFullShown(true)}
        >
          Show full info.
        </Button>
      )}
      <div className="p-2 d-grid gap-5 w-100">
        {groupedReports.map((groupedReports: CourierGroupedReports) => (
          <GroupedReportsVisualizer
            key={groupedReports.courier.id}
            groupedReports={groupedReports}
            isFullShown={isFullShown}
            editCourierSalary={editCourierSalary}
          />
        ))}
      </div>
    </ErrorWrapper>
  )
}
