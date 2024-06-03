import { MyVehicleComponent } from './my-vehicle.component'

describe('MyVehicleComponent', () => {
  it('should mount', () => {
    cy.mount(MyVehicleComponent)
  })
})