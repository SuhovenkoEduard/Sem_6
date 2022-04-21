export class ModelWrapper {
  _model: any

  constructor(model: any) {
    this._model = model
  }

  findAll = async (params: object) => (await this._model.findAll(params)).map((x: any) => x.dataValues)

  findOne = async (params: object) => (await this._model.findOne(params))?.dataValues

  create = async (params: object) => (await this._model.create(params)).dataValues

  update = async (params: object, filter: object) => this._model.update(params, filter)

  destroy = async (params: object) => this._model.destroy({ where: params })
}
