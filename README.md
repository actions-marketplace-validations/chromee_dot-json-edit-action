# dot json edit action

This action can edit json file even if "." is used in the field path like unity's package-lock.json.
This action update the origin file.

## Inputs

## `json_path`

**Required** json path

## `field_path`

**Required** field name

## `field_value`

**Required** field value

## Example usage

```
- uses: chromee/dot-json-edit-action@v1
  with:
    json_path: "path_to.json"
    field_path: "json/field/path"
    field_value: "hoge"
```
